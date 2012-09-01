using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Security.Bll.Infrastructure;
using Security.Bll;
using ValueHelper;

namespace Security.FormUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISecureService secureService;

        public MainWindow()
        {
            InitializeComponent();
            secureService = new SecureService();
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            var account = this.txtAccount.Text.Trim();
            var password = this.txtPassword.Text.Trim();

            if (String.IsNullOrEmpty(account) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("账号密码不能为空");
                return;
            }
            var result = secureService.AddAccount(account, password);

            this.txtEncode.Text = result;
        }

        private void btnEndcode_Click(object sender, RoutedEventArgs e)
        {
            var account = this.txtAccountForEncode.Text;
            this.txtEncode.Text = secureService.GetEncryptedAccount(account);
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            var account = this.txtItemForCheck.Text;

            var result = secureService.GetPassword(account);
            if (result.Length == 0 || result[0] == null)
                MessageBox.Show("对象不存在!");
            else
            {
                for (var index = 0; index < result.Length; index++)
                    result[index] += RandomHelper.NewRandom(3);
                this.txtResult.Text = StringHelper.ConvertToString(result, '\n');
            }
        }

    }
}
