namespace DevHorizons.Horus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using Newtonsoft.Json;
  
    [TestClass]
    public class CSharpTest
    {
        private readonly Invoker invoker = new Invoker();

        private readonly List<ConditionTable> conditions;

        public CSharpTest()
        {
            conditions = JsonConvert.DeserializeObject<List<ConditionTable>>(Settings.CSJsonData);
            invoker.GetConditionTableFromSource += GetConditionTableFromSource;
        }

        private Model.ConditionTable GetConditionTableFromSource(string group, string name)
        {
            return conditions.FirstOrDefault(c => c.Group.Equals(group, StringComparison.OrdinalIgnoreCase) && c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestJSONFile()
        {
            Assert.AreEqual(true, conditions.Count != 0);
        }

        [TestMethod]
        public void TestJobCategoryM5EstimateLimitLPIE()
        {
            var inputs = new Dictionary<string, string>
            {
                { "LabourHoursTotal", "5"},
                { "EstimateTotal", "10" }
            };

            var actualResults = this.invoker.ExecuteRule("LPIE", "JobCategoryM5EstimateLimit", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Result", "true"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateSupplierActiveLPFR()
        {
            var inputs = new Dictionary<string, string>
            {
                { "StatusCode", "Test3"}
            };

            var actualResults = this.invoker.ExecuteRule("FR", "ValidateActive", inputs);
            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Result", "true"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateSupplierActiveLPFR_False()
        {
            var inputs = new Dictionary<string, string>
            {
                { "StatusCode", "AnythingElse"}
            };

            var actualResults = this.invoker.ExecuteRule("FR", "ValidateActive", inputs);
            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Result", "false"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void GetApprovalLevel()
        {
            var inputs = new Dictionary<string, string>
            {
                { "JobCategory", "M1"}
            };

            var actualResults = this.invoker.ExecuteRule("FR", "ApprovalLevels", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"ApprovalLevel", "1"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateDatesI()
        {
            var inputs = new Dictionary<string, string>
            {
                { "ExpiryDate", "2015/05/15"},
                 { "ExternalProviderCode", ""}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestDates", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"User", "Yeah"},
                    {"ProviderName", DateTime.Now.AddMonths(3).ToShortDateString()},
                    {"CheckDate", Convert.ToDateTime("2019/01/19").ToString()}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateDatesII()
        {
            var inputs = new Dictionary<string, string>
            {
                { "ExpiryDate", "2020/05/15"},
                 { "ExternalProviderCode", null}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestDates", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"User", ""},
                    {"ProviderName", string.Empty},
                    {"CheckDate", Convert.ToDateTime("2020/02/20").ToString()}
                } 
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateDatesIII()
        {
            var inputs = new Dictionary<string, string>
            {
                { "ExpiryDate", "2010/05/15"},
                 { "ExternalProviderCode", " "}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestDates", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"User", " "},
                    {"ProviderName", DateTime.Now.AddDays(3).ToShortDateString()},
                    {"CheckDate", Convert.ToDateTime("2021/02/21").ToString()}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateDatesIV()
        {
            var inputs = new Dictionary<string, string>
            {
                { "ExpiryDate", "2016/05/15"},
                 { "ExternalProviderCode", "$null"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestDates", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"User", " "},
                    {"ProviderName", null},
                    {"CheckDate", Convert.ToDateTime("2015/05/15").ToString()}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateDefaultValues()
        {
            var inputs = new Dictionary<string, string>
            {
                { "ExpiryDate", "$default"},
                 { "ExternalProviderCode", "$default"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestDates", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"User", default},
                    {"ProviderName", default},
                    {"CheckDate", default(DateTime).ToString()}
                } 
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateNullableValuesI()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Distance", "6"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestDate", null},
                    {"TestDouble", null},
                    {"TestString", null}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateNullableValuesII()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Distance", "9"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestDate", Convert.ToDateTime("2009/09/09").ToString()},
                    {"TestDouble", "8"},
                    {"TestString", "8"}
                }
            };

            var result = Settings.ValidateRule(expectedResults, actualResults);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateNullableValuesIII()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Distance", "4"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestDate", Convert.ToDateTime("2004/04/04").ToString()},
                    {"TestDouble", "-105"},
                    {"TestString", "-105"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateNullableValuesIV()
        {
            var inputs = new Dictionary<string, string>
            {
                { "Distance", "5"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestDate", Convert.ToDateTime("2005/05/05").ToString()},
                    {"TestDouble", "5"},
                    {"TestString", "5"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }


        [TestMethod]
        public void ValidateNullableInputValues_BothNull()
        {
            var inputs = new Dictionary<string, string>
            {
                { "NullInt", "$null"},
                { "NullBool", "$null"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableInputValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestString", "Both are null"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateNullableInputValues_IntNull()
        {
            var inputs = new Dictionary<string, string>
            {
                { "NullInt", "$null"},
                { "NullBool", "true"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableInputValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestString", "NullInt is null"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateNullableInputValues_BoolNull()
        {
            var inputs = new Dictionary<string, string>
            {
                { "NullInt", "1"},
                { "NullBool", "$null"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestNullableInputValues", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"TestString", "NullBool is null"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateTestTwoDimI()
        {
            var inputs = new Dictionary<string, string>
            {
                { "InputString", "M1"},
                { "InputBool", "true"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestTwoDimI", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"OutString", "M100"},
                    {"OutBool", "true"},
                    {"OutInt", "100"}
                },
                new Dictionary<string, string>
                {
                    {"OutString", "M500"},
                    {"OutBool", "true"},
                    {"OutInt", "500"}
                },
                new Dictionary<string, string>
                {
                    {"OutString", "M100-500"},
                    {"OutBool", "false"},
                    {"OutInt", "1500"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }

        [TestMethod]
        public void ValidateTestTwoDimII()
        {
            var inputs = new Dictionary<string, string>
            {
                { "InputString", "M1"}
            };

            var actualResults = this.invoker.ExecuteRule("Global", "TestTwoDimI", inputs);

            var expectedResults = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"OutString", "M100"},
                    {"OutBool", "true"},
                    {"OutInt", "100"}
                }
            };

            Assert.AreEqual(true, Settings.ValidateRule(expectedResults, actualResults));
        }
    }
}