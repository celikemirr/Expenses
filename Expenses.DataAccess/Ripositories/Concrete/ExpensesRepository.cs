﻿using Expenses.DataAccess.Ripositories.Abstract;
using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.DataAccess.Ripositories.Concrete
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpensesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ExpenseModel expense)
        {
            try
            {
                _context.ExpensesTable.Add(expense);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExpenseModel> GetAllExpenses()
        {
            try
            {
                var expenses = _context.ExpensesTable.ToList();
                return expenses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ExpenseModel GetExpenseById(int id)
        {
            try
            {
                var expense = _context.ExpensesTable.Find(id);
                return expense;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ExpenseModel> Search(string searchString)
        {
            try
            {
                var searchExpenses = GetAllExpenses().Where(x => x.Title.Contains(searchString)).ToList();
                //bu ifade where fonksiyonunu kullanarak bir koşula uyan öğeleri seçer. Bu durumda 
                //her bir gider öğesi başlığa göre seçmeye yardımcı olur
                return searchExpenses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int update(ExpenseModel expense)
        {
            try
            {
                _context.Entry(expense).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Microsoft.EntityFrameworkCore.EntityState.Modified;: _context adlı bir Entity Framework veritabanı bağlamını kullanarak,
                //belirli bir nesnenin durumunu değiştiriyor. EntityState.Modified ifadesi, bu nesnenin değiştirildiğini ve veritabanında güncellenmesi gerektiğini belirtir.
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
