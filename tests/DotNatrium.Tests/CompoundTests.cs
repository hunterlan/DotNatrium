using DotNatrium.Helpers;
using DotNatrium.Infrastructure.Compound.AddCompound;
using DotNatrium.Infrastructure.Compound.GetCompound;
using DotNatrium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNatrium.Tests
{
    [TestClass]
    public class CompoundTests
    {
        private GetCompoundQueryHandler _handler;
        private AddCompoundQueryHandler _addHandler;
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
        public async void GetCompoundDataTest()
        {
            Compound expectedCompound = new()
            {
                Data = new()
                {
                    Name = "Salt",
                    Symbol = "Na2CO3"
                }
            };
            var actualCompound =
                await _handler.GetCompound(new GetCompoundQuery { DataId = 4 }, CancellationToken.None);
            if (actualCompound?.Data is null) Assert.Fail();
            Assert.AreEqual(expectedCompound.Data.Name, actualCompound.Data.Name);
        }
    }
}