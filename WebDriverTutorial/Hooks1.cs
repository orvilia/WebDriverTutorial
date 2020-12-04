using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace WebDriverTutorial
{
    [Binding]

    public class Hooks1
    {

      
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        public Hooks1( FeatureContext featureContext, ScenarioContext scenarioContext) 
        {
            
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;


        [BeforeTestRun]
        public static void TestInitalize()
        {
            //Initialize the Report
            var htmlReporter = new ExtentHtmlReporter(@"C:\Logs\Report.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.ReportName = "Automation Test Report";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();


            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                 
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                    
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                    
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    
                }
            }



        }

        [BeforeScenario]
        public void Initialize()
        {
           

            //Create feature name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Get scenario name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

        }


        [AfterScenario]
        public void TestStop()
        {
           

        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Write the report to the report directory
            extent.Flush();


        }

    }

}
