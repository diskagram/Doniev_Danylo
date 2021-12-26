using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;



public class Driver : ChromeDriver
{
    String login;
    String password;
    String dafault_text;


    public Driver(string path, Dictionary<string, string> my_data) : base(path)
    {
        this.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";
        this.login = my_data["login"];
        this.password = my_data["password"];
        this.dafault_text = my_data["dafault_text"];

    }

    public string Exception(string module, string span = ".//span[@class = \"validation-error\"]")
    {
        string answer, error;
        try
        {
            answer = "ERROR";
            error = this.FindElement(By.XPath(span)).Text;
        }
        catch (NoSuchElementException)
        {
            answer = "SUCCESS";
            error = "";
        }
        Console.Write($"{answer} {error}, in {module} \n");
        return answer;
    }

    public string LogIn()
    {
        this.FindElement(By.Name("txtUsername")).SendKeys(this.login);
        this.FindElement(By.Name("txtPassword")).SendKeys(this.password);
        this.FindElement(By.Name("Submit")).Click();
        string answer = this.Exception("login", ".//span[@id=\"spanMessage\"]");
        return answer;
        //TODO: assert answer == "ERROR"

    }

    public void ToUsers()
    {
        this.FindElement(By.XPath("/html/body/div[1]/div[2]/ul/li[1]/a/b")).Click();
        this.FindElement(By.XPath("/html/body/div[1]/div[2]/ul/li[1]/ul/li[2]/a")).Click();
        this.FindElement(By.XPath("/html/body/div[1]/div[2]/ul/li[1]/ul/li[2]/ul/li[1]/a")).Click();
    }
    public string AddInfo(string button)
    {
        this.FindElement(By.Name(button)).Click();
        this.FindElement(By.XPath("//*[@id=\"jobTitle_jobTitle\"]")).SendKeys(this.dafault_text);
        this.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/form/fieldset/ol/li[2]/textarea")).SendKeys(this.dafault_text);
        this.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/form/fieldset/ol/li[4]/textarea")).SendKeys(this.dafault_text);
        this.FindElement(By.Name("btnSave")).Click();
        string answer = this.Exception("AddUsers");
        return answer;
        //TODO: assert answer == "ERROR"
    }
    public string Check()
    {
        this.FindElement(By.XPath($"//*[text()='{this.dafault_text}']")).Click();
        string[] separator = { "jobTitleId=" };
        string pay_grade_id = this.Url.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries)[1];
        return pay_grade_id;

    }
    public string Delete(string pay_grade_id)
    {
        int id = Int32.Parse(pay_grade_id);
        string answer;
        this.FindElement(By.XPath($"//table[@id='resultTable']/tbody/tr/td/input[@type='checkbox' and @value={id}]")).Click();
        this.FindElement(By.Name("btnDelete")).Click();
        this.FindElement(By.Id("dialogDeleteBtn")).Click();
        try
        {
            this.FindElement(By.XPath($"//*[text()='{this.dafault_text}']"));
            answer = "ERROR";
        }
        catch (NoSuchElementException)
        {
            answer = "SUCCESS";
        }
        Console.Write($"Delete: {answer}\n");
        return answer;
        //TODO: assert answer == "ERROR"
    }



}




class MainClass
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> my_data = new Dictionary<string, string>();
        my_data.Add("login", "Admin");
        my_data.Add("password", "admin123");
        my_data.Add("dafault_text", "one");

        string path_to_driver = "/Users/donevd/Downloads/driver";
        Driver driver = new Driver(path_to_driver, my_data);
        int sleep_lag = 0;
        driver.LogIn();
        Thread.Sleep(sleep_lag);
        driver.ToUsers();
        Thread.Sleep(sleep_lag);
        driver.AddInfo("btnAdd");
        Thread.Sleep(sleep_lag);
        driver.ToUsers();
        Thread.Sleep(sleep_lag);
        string pay_grade_id = driver.Check();
        driver.AddInfo("btnSave");
        Thread.Sleep(sleep_lag);
        driver.ToUsers();
        Thread.Sleep(sleep_lag);
        driver.Delete(pay_grade_id);
        Thread.Sleep(sleep_lag * 3000);



    }
}
