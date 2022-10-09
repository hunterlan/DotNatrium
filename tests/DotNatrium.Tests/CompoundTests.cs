using DotNatrium.Helpers;
using DotNatrium.Models;
using Infrastructure.Compound.GetCompoundQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace DotNatrium.Tests
{
    [TestClass]
    public class CompoundTests
    {
        private GetCompoundQueryHandler _handler;
        private ApplicationContext _context;

        public CompoundTests()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            _context = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(config["connectionString"])
                .Options);
            _context.Database.EnsureCreated();
            _handler = new GetCompoundQueryHandler(_context);
        }
        [TestMethod]
        public void GetCompoundDataTest()
        {
            Compound expectedCompound = new()
            {
                Data = new()
                {
                    Name = "Salt",
                    Symbol = "Na2CO3"
                }
            };
            var actualCompound = _handler.GetCompound(new GetCompoundQueryRequest { Id = 1 }, CancellationToken.None);
            if (actualCompound is null) Assert.Fail();
            Assert.AreEqual(expectedCompound.Data.Name, actualCompound.Data.Name);
        }
    }
}