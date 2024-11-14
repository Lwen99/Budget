using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budget.Data;
using Budget.Models;
using Budget.Models.ViewModels;

namespace Budget.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        [HttpGet("Transactions/Index/{id}")]
        public async Task<IActionResult> Index([FromRoute]int id)
        {
            IEnumerable<Transaction> transaction = await _context.Transactions.Where(t => t.AccountId == id).
                Include(t=>t.Category).ToListAsync();

            TransactionsViewModelWithAccountId model = new TransactionsViewModelWithAccountId
            {
                AccountId = id,
                Transaction = transaction
            };
            
            return View(model);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // Filter
        public async Task<IActionResult> FilterData(string name, int id)
        {
            var query = _context.Transactions.Where(t=>t.AccountId == id).Include(t => t.Category).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Description.Contains(name));
            }
            var transactions = await query.ToListAsync();
          
            return PartialView("Transaction/_TransactionsDisplay", transactions);

        }
        public async Task<IActionResult> FilterByCategory( int id)
        {
            var query = _context.Transactions.Where(t => t.AccountId == id).Include(t => t.Category).AsQueryable();


            query = query.OrderBy(t => t.Category.Name == null);
            var transactions = await query.ToListAsync();

            return PartialView("Transaction/_TransactionsDisplay", transactions);

        }

        // Get Forms
        public async Task<IActionResult> LoadTransactionForm(int formId, int accountId)
          {
            var categories = await _context.Categories.ToListAsync();

            var catModel = new CategoriesViewModel
            {
                CategoriesDropDown = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                })
            };
     
            var model = new TransactionsViewModel
            {
                Categories = catModel,
                AccountId = accountId,
            };

            var depositModel = new DepositViewModel
            {
                AccountId = accountId
            };
            switch (formId)
            {
                case 0:
                    return PartialView("TransactionForms/_PurchaseForm", model);
                case 1:
                    return PartialView("TransactionForms/_DepositForm", depositModel);
                default:
                    return View();
            }
        }

        // GET: Transactions/Create

        [HttpGet("Transactions/Create/{id}")]
        public async Task<IActionResult> Create([FromRoute] int id)
        {

            var transactionTypesList = Enum.GetValues(typeof(TransactionTypes)).Cast<TransactionTypes>().Select(
                                                                            e => new SelectListItem
                                                                            {
                                                                                Value = ((int)e).ToString(),
                                                                                Text = e.ToString()
                                                                            }).ToList();

            TransactionTypesViewModel model = new TransactionTypesViewModel()
            {
                AccountId = id,
                TransactionTypes = transactionTypesList
            };
            return View(model);
        }


        [HttpGet("Transactions/Deposit/{id}")]

        public async Task<IActionResult> Deposit([FromRoute] int id)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(DepositViewModel deposit)
        {
            if (ModelState.IsValid)
            {
                Account account = await _context.Account.FirstOrDefaultAsync(i => i.Id == deposit.AccountId);
                if (account != null)
                {
                    account.Balance += deposit.Amount ?? 0;
                    Transaction tran = new Transaction()
                    {
                        CreatedDate = DateTime.Now,
                        Amount = deposit.Amount,
                        Description = deposit.Description,
                        AccountId = deposit.AccountId,
                        CategoryId = null,
                        Type = TransactionTypes.Deposit,
                        EndingBalance = account.Balance,


                    };
                    _context.Add(tran);
                    
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
             

                return RedirectToAction("Index", new { id = deposit.AccountId });

            }
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TransactionsViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                Account account = await _context.Account.FirstOrDefaultAsync(i => i.Id == transaction.AccountId);
                if(account != null)
                {
                    if(account.Balance <= transaction.Amount)
                    {
                        //give a warning that account balance is empty or negative
                    }
                    account.Balance -= (transaction.Amount ?? 0);

                    Transaction tran = new Transaction()
                    {
                        CreatedDate = DateTime.Now,
                        Description = transaction.Description,
                        Amount  = transaction.Amount,
                        AccountId = account.Id,
                        CategoryId = transaction.SelectedCategoryId,
                        Type = transaction.SelectedType,
                        EndingBalance = account.Balance,

                        
                    };
                    _context.Transactions.Add(tran);
                    _context.Update(account);
                    await _context.SaveChangesAsync();

                }

                return RedirectToAction("Index", new { id = transaction.AccountId });
            }
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedDate,Description,Withdrawal,Deposit,Balance")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
