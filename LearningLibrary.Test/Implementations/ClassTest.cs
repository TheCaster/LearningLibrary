using LearningLibrary.Implementation;
using LearningLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace LearningLibrary.Test.Implementations
{
    public class ClassTest : IDisposable
    {
        private IClass _class;

        // Constructor
        public ClassTest()
        {            
            _class = new Class();
        }

        // Destructor        
        public void Dispose()
        {
            _class.Dispose();
        }


        [Fact(DisplayName = "DoParallelTest")]
        public void DoParallelTest()
        {
            // Run
            _class.DoParallel();

            // Test
            Assert.True(true);
        }
        
        [Fact(DisplayName = "DoWait")]
        public void DoWaitTest()
        {
            // Run
            _class.DoWait();

            // Test
            Assert.True(true);
        }

        [Fact(DisplayName = "DontWaitTest")]
        public void DontWaitTest()
        {
            // Run
            var result = _class.DontWait();

            // Test
            Assert.Equal(0, result.Result);
        }

        [Fact(DisplayName = "DontWaitWithResult")]
        public void DontWaitWithResultTest()
        {
            // Run
            var result = _class.DontWaitWithResult();

            // Test
            Assert.Equal(0, result.Result);
        }


        [Fact(DisplayName = "WaitForResult")]
        public void WaitForResultTest()
        {
            // Run
            var result = _class.WaitForResult();

            // Test
            Assert.Equal(0, result.Result);
        }

    }
}