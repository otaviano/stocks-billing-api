﻿using MongoDB.Driver;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Stocks.Billing.Infra.Data.NoSql.Repositories
{
  public class StockNoSqlRepository : IStockNoSqlRepository
  {
    private readonly IMongoDatabase mongoDatabase;

    public StockNoSqlRepository(IConfiguration configuration)
    {
      var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
      mongoDatabase = client.GetDatabase("read-data");
    }

    private IMongoCollection<T> GetCollection<T>() => 
      mongoDatabase.GetCollection<T>(nameof(T));

    public IEnumerable<Stock> GetAll() =>
      GetCollection<Stock>().AsQueryable();

    IEnumerable<Stock> IStockNoSqlRepository.Search(Guid hash, string ticker) =>
      GetCollection<Stock>().AsQueryable()
        .Where(p => p.Hash == hash || p.Ticker == ticker);
    
    public async Task Create(Stock stock) =>
      await GetCollection<Stock>().InsertOneAsync(stock);
  }
}
