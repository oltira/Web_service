using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TEP_WebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TEP_WebService.init();
        }
        public class Informazioni_Film
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Plot { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Actors { get; set; }
            public string Language { get; set; }
            public string Country { get; set; }
            public string Awards { get; set; }
            public string imdbRating { get; set; }
            public string BoxOffice { get; set; }
            public string Poster { get; set; }
        }
        public class TEP_WebService
        {
            static HttpClient client = new HttpClient();
            public static void init()
            {
                client.BaseAddress = new Uri("https://www.omdbapi.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            }
            public static async Task<Informazioni_Film> OttieniInformazioni(string path)
            {
                Informazioni_Film richiesta = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    richiesta = await JsonSerializer.DeserializeAsync<Informazioni_Film>(await response.Content.ReadAsStreamAsync());
                }
                return richiesta;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string titolo = textBox1.Text.Replace(" ", "+");
            string informazioni = "/?apikey=4e2bf5e3=" + titolo;
            Informazioni_Film a = new Informazioni_Film();
            a = await TEP_WebService.OttieniInformazioni(informazioni);
            if (a != null)
            {
                richTextBox1.Text = "TITOLO: " + a.Title + "\n"
                + "USCITA: " + a.Year + "\n"
                + "GENERE: " + a.Genre + "\n"
                + "TRAMA: " + a.Plot + "\n"
                + "DURATA: " + a.Runtime + "\n"
                + "REGISTA: " + a.Director + "\n"
                + "SCENEGGIATORI: " + a.Writer + "\n"
                + "CAST: " + a.Actors + "\n"
                + "LINGUA: " + a.Language + "\n"
                + "PAESE DI PRODUZIONE: " + a.Country + "\n"
                + "PREMI: " + a.Awards + "\n"
                + "VOTAZIONE FILM: " + a.imdbRating + "\n"
                + "INCASSI USA: " + a.BoxOffice + "\n";
                pictureBox1.LoadAsync(a.Poster);
            }
            else
                MessageBox.Show("Errore");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}