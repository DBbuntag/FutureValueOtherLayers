using FutureValue.Application.Commands;
using FutureValue.Application.Interfaces;
using FutureValue.Persistence;
using FutureValue.UnitTests.Shared;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.UnitTests.Application
{
    public class ComputeFutureValueTests
    {
        private FutureValueCommands futureValueCommands = new FutureValueCommands(null);
        [Test]
        public void ComputeFutureValue()
        {
            var result = futureValueCommands.ComputeFutureValue(1, 1000, 1, 10);

            Assert.AreEqual(result.FutureValue, 1100);
        }
    }
}
