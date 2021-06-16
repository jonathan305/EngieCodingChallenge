using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Powerplant_Coding_Challenge.WpfApiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("http://localhost:8888/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            string jsonPayload = txtRequest.Text;
            txtResponse.Text = PostPayloadAsync(jsonPayload).Result;
        }

        static async Task<string> PostPayloadAsync(string jsonPayload)
        {

            var httpStringContent = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json"); ;
            HttpResponseMessage response = httpClient.PostAsync("ProductionPlan", httpStringContent).Result;
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return await response.Content.ReadAsStringAsync();
        }

        private void radPayload1_Checked(object sender, RoutedEventArgs e)
        {
            string payload1 = File.ReadAllText(@"C:\Users\User\Source\Repos\powerplant-coding-challenge-Jonathan\powerplant-coding-challenge-master\powerplant-coding-challenge-master\example_payloads\payload1.json");
            txtRequest.Text = payload1;
        }

        private void radPayload2_Checked(object sender, RoutedEventArgs e)
        {
            string payload1 = File.ReadAllText(@"C:\Users\User\Source\Repos\powerplant-coding-challenge-Jonathan\powerplant-coding-challenge-master\powerplant-coding-challenge-master\example_payloads\payload2.json");
            txtRequest.Text = payload1;
        }

        private void radPayload3_Checked(object sender, RoutedEventArgs e)
        {
            string payload1 = File.ReadAllText(@"C:\Users\User\Source\Repos\powerplant-coding-challenge-Jonathan\powerplant-coding-challenge-master\powerplant-coding-challenge-master\example_payloads\payload3.json");
            txtRequest.Text = payload1;
        }
    }
}
