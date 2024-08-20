using System.ComponentModel.Design;

namespace Suma2429841
{
    public partial class MainPage : ContentPage
    {
        private  readonly LocalDbService _dbService;
        private int _editResultadoId;
        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetResultados());
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
        }

        private async void listview_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            var resultado = (Resultado)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null ,"Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editResultadoId = resultado.Id;
                    Entryprimernumero.Text = resultado.numero1;
                    Entrysegundonumero.Text = resultado.numero2;
                    labelResultado.Text = resultado.Suma;
                    break;

                case "Delete":
                    await _dbService.Delete(resultado);
                    listview.ItemsSource = await _dbService.GetResultados();
                    break;
            }

        }

        private async void SumarBtn_Clicked(object sender, EventArgs e)
        {
            string numero1 = Entryprimernumero.Text;
            string numero2 = Entrysegundonumero.Text;

            if (!int.TryParse(numero1, out int Numero1) || !int.TryParse(numero2, out int Numero2))
            {
                await DisplayAlert("Error", "Ingresa numeros enteros", "Aceotar");
                return;
            }

            int Suma = Numero1 + Numero2; 
            labelResultado.Text = Suma.ToString();


            if (_editResultadoId == 0)
            {
                await _dbService.Create(new Resultado
                {
                    numero1 = Entryprimernumero.Text,
                    numero2 = Entrysegundonumero.Text,
                    Suma    = labelResultado.Text 
                });
            }

            else
            {
                await _dbService.Update(new Resultado
                {
                    Id = _editResultadoId,
                    numero1 = Entryprimernumero.Text,
                    numero2 = Entrysegundonumero.Text,
                    Suma = labelResultado.Text
                });

                _editResultadoId = 0;
            }

            Entryprimernumero.Text = string.Empty;
            Entrysegundonumero.Text = string.Empty;
            labelResultado.Text = string.Empty;

            listview.ItemsSource = await _dbService.GetResultados();
        }
    }

}
