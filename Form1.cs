using CEP.Models;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace CEP
{
    public partial class Form1 : Form
    {
        private string _BASEURL = "https://viacep.com.br/ws/{0}/json/";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cep = maskedTextBox1.Text.Trim();

            cep = cep.Replace(".", "").Replace("-", "").Replace(",", "");

            if (!string.IsNullOrEmpty(cep))
            {
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        var response = httpClient.GetAsync(string.Format(_BASEURL, cep)).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            var endereco = Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(result);
      
                            Endereco newEndereco = new Endereco(endereco.CEP, endereco.Logradouro, endereco.Complemento, endereco.UF, endereco.Bairro, endereco.DDD);

                            richTextBox1.Text = $"CEP: {newEndereco.CEP}\n";
                            richTextBox1.Text += $"Logradouro: {newEndereco.Logradouro}\n";
                            richTextBox1.Text += $"Complemento: {newEndereco.Complemento}\n";
                            richTextBox1.Text += $"UF: {newEndereco.UF}\n";
                            richTextBox1.Text += $"Bairro: {newEndereco.Bairro}\n";
                            richTextBox1.Text += $"DDD: {newEndereco.DDD}\n";


                        }
                        else
                        {
                            MessageBox.Show($"Consulta ao CEP {cep} não retornou sucesso", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao buscar CEP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"CEP inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
