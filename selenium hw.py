from time import sleep
from selenium.webdriver import Chrome
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException


class MyInputOutput:
    def __init__ (self, kwargs):
        self.login = kwargs.get('login')
        self.password = kwargs.get('password')
        self.payGrade_name = kwargs.get('payGrade_name')
        self.currencyName = kwargs.get('currencyName')
        self.minSalary = kwargs.get('minSalary')
        self.maxSalary = kwargs.get('maxSalary')


class Driver(Chrome):
    def __init__ (self):
        super().__init__()
        self.get("https://opensource-demo.orangehrmlive.com/index.php/auth/login")

    @staticmethod
    def alert (module, span='.//span[@class = "validation-error"]'):
        err = 'empty'
        try:
            answer = 'ElementFound'
            err = driver.find_element(By.XPATH, span).text
        except NoSuchElementException:
            answer = f'NoSuchElementException in {module}'
        assert (answer != 'ElementFound' or err == ""), f"ERROR - |{err}| in {module}"

    def login (self):
        self.find_element(By.NAME, "txtUsername").send_keys(my_input.login)
        self.find_element(By.NAME, "txtPassword").send_keys(my_input.password)
        self.find_element(By.NAME, "Submit").click()
        self.alert('login', './/span[@id="spanMessage"]')

    def to_grade (self):
        self.find_element(By.ID, "menu_admin_viewAdminModule").click()
        self.find_element(By.ID, "menu_admin_Job").click()
        self.find_element(By.ID, "menu_admin_viewPayGrades").click()

    def add_grade (self):
        self.find_element(By.NAME, "btnAdd").click()
        self.find_element(By.ID, "payGrade_name").send_keys(my_input.payGrade_name)
        self.find_element(By.NAME, "btnSave").click()
        self.alert('payGrade_name')

    def add_curr (self):
        self.alert('payGrade_name')
        self.find_element(By.ID, "btnAddCurrency").click()
        self.find_element(By.NAME, "payGradeCurrency[currencyName]").send_keys(my_input.currencyName + Keys.RETURN)
        self.find_element(By.NAME, "payGradeCurrency[minSalary]").send_keys(my_input.minSalary + Keys.RETURN)
        self.alert('currencyName')
        self.alert('minSalary')
        self.find_element(By.NAME, "payGradeCurrency[maxSalary]").send_keys(my_input.maxSalary + Keys.RETURN)
        self.alert('maxSalary')
        self.find_element(By.NAME, "btnSaveCurrency").click()

    def check (self):
        self.find_element(By.XPATH, "//*[text()='" + my_input.payGrade_name + "']").click()
        pay_grade_id = self.current_url.split('payGradeId=')[1]
        print(my_input.currencyName.split(' - ')[1] == self.find_element(By.XPATH,
                                                                         "//table[@id='tblCurrencies']/tbody/tr[@class='odd']/td[2]").text)
        print(my_input.minSalary == self.find_element(By.XPATH,
                                                      "//table[@id='tblCurrencies']/tbody/tr[@class='odd']/td[3]").text)
        print(my_input.maxSalary == self.find_element(By.XPATH,
                                                      "//table[@id='tblCurrencies']/tbody/tr[@class='odd']/td[4]").text)
        return pay_grade_id

    def delete (self):
        driver.find_element(By.XPATH,
                            f"//table[@id='resultTable']/tbody/tr/td/input[@type='checkbox' and @value={int(pay_grade_id)}]").click()
        driver.find_element(By.NAME, "btnDelete").click()
        driver.find_element(By.ID, "dialogDeleteBtn").click()
        try:
            driver.find_element(By.XPATH, "//*[text()='" + my_input.payGrade_name + "']")
            print("didnt delete")
        except NoSuchElementException:
            print("deleted")


secret1 = {"login": 'Admin',
           "password": 'admin123',
           "payGrade_name": 'DDonev',
           "currencyName": 'AUD - Australian Dollar',
           "minSalary": '100.00',
           "maxSalary": '200.00'}
my_input = MyInputOutput(secret1)
driver = Driver()
driver.login()
driver.to_grade()
driver.add_grade()
driver.add_curr()
driver.to_grade()
pay_grade_id = driver.check()
driver.to_grade()
driver.delete()
sleep(10)
driver.quit()