//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Gherkin.Model;
//using AventStack.ExtentReports.Reporter;
//using BoDi;
//using SpecFlowSelenium.Configuration;
//using TechTalk.SpecFlow;

//namespace SpecFlowSelenium.Hooks
//{
//    [Binding]
//    class Hooks
//    {
//        private static ExtentTest featureName;
//        private static ExtentTest scenario;
//        private static ExtentReports extent;
//        private readonly IObjectContainer _objectContainer;
//        private static DriverConfiguration configuration;
//        private readonly ScenarioContext _scenarioContext;
//        private static FeatureContext _featureContext;

//        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
//        {
//            _objectContainer = objectContainer;
//            _scenarioContext = scenarioContext;
//            _featureContext = featureContext;
//        }

//        [BeforeScenario()]
//        public void createBrowser()
//        {
//            configuration = new DriverConfiguration();
//            _objectContainer.RegisterInstanceAs<DriverConfiguration>(configuration);
//            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
//        }

//        [AfterScenario()]
//        public void closeBrowser()
//        {
//            configuration.WebDriver.Quit();
//        }

//        [BeforeTestRun]
//        public static void InitializeReport()
//        {
//            //Initialize Extent report before test starts
//            var htmlReporter = new ExtentHtmlReporter(@"..\..\..\Reports\ExtentReport.html");
//            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
//            //Attach report to reporter
//            extent = new ExtentReports();
//            extent.AttachReporter(htmlReporter);
//        }

//        [AfterTestRun]
//        public static void TearDownReport()
//        {
//            //Flush report once test completes
//            extent.Flush();
//        }

//        [BeforeFeature]
//        public static void BeforeFeature(FeatureContext featureContext)
//        {
//            //Create dynamic feature name
//            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
//        }

//        [AfterStep]
//        public void InsertReportingSteps()
//        {
//            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

//            if (_scenarioContext.TestError == null)
//            {
//                if (stepType == "Given")
//                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
//                else if (stepType == "When")
//                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
//                else if (stepType == "Then")
//                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
//                else if (stepType == "And")
//                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
//            }
//            else if (_scenarioContext.TestError != null)
//            {
//                if (stepType == "Given")
//                {
//                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
//                    .Fail(_scenarioContext.TestError.InnerException)
//                    .Fail("details", MediaEntityBuilder.CreateScreenCaptureFromBase64String(configuration.getScreenShotBase64()).Build());
//                }
//                else if (stepType == "When")
//                {
//                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
//                        .Fail(_scenarioContext.TestError.InnerException)
//                        .Fail("details", MediaEntityBuilder.CreateScreenCaptureFromBase64String(configuration.getScreenShotBase64()).Build());
//                }
//                else if (stepType == "Then")
//                {
//                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
//                        .Fail(_scenarioContext.TestError.Message)
//                        .Fail("details", MediaEntityBuilder.CreateScreenCaptureFromBase64String(configuration.getScreenShotBase64()).Build());
//                }

//            }

//            //Pending Status
//            if (_scenarioContext.ScenarioExecutionStatus.Equals("StepDefinitionPending"))
//            {
//                if (stepType == "Given")
//                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
//                else if (stepType == "When")
//                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
//                else if (stepType == "Then")
//                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
//            }
//        }
//    }
//}
