using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Modele;

namespace Vues
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Article> _articles;
        public ObservableCollection<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; }
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        private string _enteredNumber;
        public string EnteredNumber
        {
            get { return _enteredNumber; }
            set
            {
                _enteredNumber = value;
                OnPropertyChanged("EnteredNumber");
            }
        }

        private float _quEntree;
        public float QuEntree
        {
            get { return _quEntree; }
            set { _quEntree = value; }
        }

        private ulong _cb;
        public ulong CB
        {
            get { return _cb; }
            set { _cb = value; }
        }

        private ulong _codeBarre;
        public ulong CodeBarre
        {
            get { return _codeBarre; }
            set { _codeBarre = value; }
        }

        private string _denomination;
        public string Denomination
        {
            get { return _denomination; }
            set { _denomination = value; }
        }

        private int _quantite;
        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        private float _prix;
        public float Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        private int _points;
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private string _numeroCarteFidelite;
        public string NumeroCarteFidelite
        {
            get { return _numeroCarteFidelite; }
            set { _numeroCarteFidelite = value; }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        private System.DateTime _dateNaissance;
        public System.DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        private int _numTicket;
        public int NumTicket
        {
            get { return _numTicket; }
            set { _numTicket = value; }
        }

        private Ticket _ticket;
        public Ticket Ticket
        {
            get { return _ticket; }
            set
            {
                _ticket = value;
                OnPropertyChanged("Ticket");
            }
        }

        private ObservableCollection<MesArticles> _articlesTicket;
        public ObservableCollection<MesArticles> ArticlesTicket
        {
            get { return _articlesTicket; }
            set { _articlesTicket = value; }
        }

        private Article _articleEnCours;
        public Article ArticleEnCours
        {
            get { return _articleEnCours; }
            set
            {
                _articleEnCours = value;
                OnPropertyChanged("ArticleEnCours");
            }
        }

        public ICommand AppendNumberCommand { get; private set; }
        public ICommand OpenNewArticleWindowCommand { get; private set; }
        public ICommand OpenNewClientWindowCommand { get; private set; }
        public ICommand XButtonCommand { get; private set; }
        public ICommand PLUButtonCommand { get; private set; }
        public ICommand SaveArticleCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand SaveClientCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            OpenNewArticleWindowCommand = new RelayCommand(() => OpenNewArticleWindow());
            OpenNewClientWindowCommand = new RelayCommand(() => OpenNewClientWindow());
            AppendNumberCommand = new RelayCommand<string>(AppendNumber);
            XButtonCommand = new RelayCommand(XButtonClicked);
            PLUButtonCommand = new RelayCommand(PLUButtonClicked);
            SaveArticleCommand = new RelayCommand(SaveArticle);
            CancelCommand = new RelayCommand(Cancel);
            SaveClientCommand = new RelayCommand(SaveClient);

            Articles = new ObservableCollection<Article>();
            Clients = new ObservableCollection<Client>();
            ArticlesTicket = new ObservableCollection<MesArticles>();

            LoadNumTicket();
            LoadArticles();
            LoadClients();

            Ticket = new Ticket();
            Ticket.NumTicket = _numTicket;
            ArticleEnCours = new Article();
        }

        private void OpenNewArticleWindow()
        {
            MainWindowNewArticle newArticleWindow = new MainWindowNewArticle();
            newArticleWindow.Show();
        }

        private void OpenNewClientWindow()
        {
            MainWindowNewClient newClientWindow = new MainWindowNewClient();
            newClientWindow.Show();
        }

        private void AppendNumber(string number)
        {
            EnteredNumber += number;
            OnPropertyChanged("EnteredNumber");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void XButtonClicked()
        {
            if (float.TryParse(EnteredNumber, out float result))
            {
                _quEntree = result;
            }
            else
            {
                _quEntree = 1;
            }
            Console.WriteLine(_quEntree);
            ClearEnteredNumber();
        }

        private void ClearEnteredNumber()
        {
            EnteredNumber = string.Empty;
        }

        private void PLUButtonClicked()
        {
            Article _articleEnCours = new Article();
            if (ulong.TryParse(EnteredNumber, out ulong result))
            {
                CB = result;
                Console.WriteLine(_cb);
                bool articleFound = false;
                foreach (Article article in Articles)
                {
                    if (article.CodeBarre == CB)
                    {
                        _articleEnCours = article;
                        articleFound = true;
                        break;
                    }
                }

                if (articleFound)
                {
                    ArticleEnCours = _articleEnCours;
                    MesArticles venteArticle = new MesArticles((int)QuEntree, _articleEnCours);
                    Ticket.ArticlesEnCours.Add(venteArticle);
                    ArticlesTicket.Add(venteArticle);

                    Console.WriteLine(Ticket.ToString());
                }
                else
                {
                    MessageBox.Show("Article inexistant, mettre à jour les articles.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("ERREUR CB", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClearEnteredNumber();
        }

        private void SaveArticle()
        {
            Article newArticle = new Article()
            {
                CodeBarre = CodeBarre,
                Denomination = Denomination,
                Quantite = Quantite,
                Prix = Prix,
                Points = Points
            };

            Articles.Add(newArticle);
            SaveArticles();
            ClearArticleFields();
        }

        private void Cancel()
        {
            ClearArticleFields();
        }

        private void ClearArticleFields()
        {
            CodeBarre = 0;
            Denomination = string.Empty;
            Quantite = 0;
            Prix = 0;
            Points = 0;
        }

        private void SaveClient()
        {
            if (ulong.TryParse(NumeroCarteFidelite, out ulong carteFidelite))
            {
                Client newClient = new Client()
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    DateNaissance = DateNaissance,
                    CarteFidelite = carteFidelite,
                    Points = Points
                };

                Clients.Add(newClient);
                SaveClients();
                ClearClientFields();
            }
            else
            {
                MessageBox.Show("Numéro de carte invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ClearClientFields()
        {
            Nom = string.Empty;
            Prenom = string.Empty;
            DateNaissance = DateTime.Now;
            NumeroCarteFidelite = string.Empty;
            Points = 0;
        }

        private void LoadNumTicket()
        {
            string filePath = "NumTicket.dat";

            if (File.Exists(filePath))
            {
                string numTicketString = File.ReadAllText(filePath);
                if (int.TryParse(numTicketString, out int numTicket))
                {
                    _numTicket = numTicket;
                }
            }
        }

        private void SaveNumTicket()
        {
            string filePath = "NumTicket.dat";
            File.WriteAllText(filePath, _numTicket.ToString());
        }

        private void LoadArticles()
        {
            string filePath = "Articles.dat";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<Article> loadedArticles = JsonSerializer.Deserialize<List<Article>>(json);
                foreach (Article article in loadedArticles)
                {
                    Articles.Add(article);
                }
            }
        }

        private void SaveArticles()
        {
            string filePath = "Articles.dat";
            string json = JsonSerializer.Serialize(Articles.ToList());
            File.WriteAllText(filePath, json);
        }

        private void LoadClients()
        {
            string filePath = "Clients.dat";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<Client> loadedClients = JsonSerializer.Deserialize<List<Client>>(json);
                foreach (Client client in loadedClients)
                {
                    Clients.Add(client);
                }
            }
        }

        private void SaveClients()
        {
            string filePath = "Clients.dat";
            string json = JsonSerializer.Serialize(Clients.ToList());
            File.WriteAllText(filePath, json);
        }
    }
}
