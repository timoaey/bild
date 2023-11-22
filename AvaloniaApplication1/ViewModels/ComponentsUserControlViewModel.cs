using gavmeaw.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace gavmeaw.ViewModels
{
    public class ComponentsUserControlViewModel : ViewModelBase
    {
        private Bilder _selectedBilder;
        public Bilder SelectedBilder
        {
            get => _selectedBilder;
            set => this.RaiseAndSetIfChanged(ref _selectedBilder, value);
        }

        private HttpClient client = new HttpClient();
        private ObservableCollection<Bilder> _Bilders;
        public ObservableCollection<Bilder> Bilders
        {
            get => _Bilders;
            set => this.RaiseAndSetIfChanged(ref _Bilders, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public ComponentsUserControlViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:5143");
            Update();
        }

        public async Task Update()
        {
            var response = await client.GetAsync("/Bilders");
            if (!response.IsSuccessStatusCode)
            {
                Message = $"Ошибка сервера {response.StatusCode}";
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Message = "Пустой ответ от сервера";
                return;
            }
            Bilders = JsonSerializer.Deserialize<ObservableCollection<Bilder>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedBilder == null) return;
            var response = await client.DeleteAsync($"/Bilders/{SelectedBilder.id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            Bilders.Remove(SelectedBilder);
            SelectedBilder = null;
            Message = "";
        }

        public async Task Add()
        {
            var bilder = new Bilder();
            var response = await client.PostAsJsonAsync($"/Bilders", bilder);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Bilder>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            bilder= content;
            Bilders.Add(bilder);
            SelectedBilder = bilder;
        }

        public async Task Edit()
        {
            var response = await client.PutAsJsonAsync($"/Bilders", SelectedBilder);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Bilder>();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedBilder = content;
        }
    }
}
