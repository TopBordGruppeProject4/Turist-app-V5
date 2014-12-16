using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TursitAppV4.Model;
using Tursit_app_V5.Annotations;
using Tursit_app_V5.Common;
using Tursit_app_V5.model;
using Tursit_app_V5.view;

namespace Tursit_app_V5.viewmodel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private static Userlist _userlist = Userlist.UserlistInstance;
        private static Picture _selectedPicture;

        public static Userlist Userlist { get { return _userlist; } }

        public static Picture SelectedPicture
        {
            get { return _selectedPicture; }
            set { _selectedPicture = value; }
        }

        public User CurrentUser
        {
            get { return Userlist.CurrentUser; }
        }

        public static Gallery SelectedGallery { get; set; }
        public static Gallery natureGallery;
        public static Gallery attractionsGallery;
        public static Gallery restaurentsGallery;
        public static Gallery nightlifeGallery;

        public static Gallery FavoriteGallery = new Gallery("Favoritter", new ObservableCollection<Picture>());

        public MainViewModel()
        {
            var temp = new ObservableCollection<Picture>();
            temp.Add(new Picture("Boserup", "ms-appx:///Assets/Boserup.png", "Boserup skov, beliggende på Boserupvej 89, er en frodig alsidig skov, hvor du kan opleve et stort og varieret dyre- og fugleliv. Skoven har en rig historie, og kan byde på masser af forskellige oplevelser. Du kan f.eks. prøve at spadserer på en af de mange ruter, eller du kan grille på lerskrænten og derefter overnatte i et shelter.", "http://naturstyrelsen.dk/naturoplevelser/naturguider/boserup-skov/"));
            temp.Add(new Picture("Byparken", "ms-appx:///Assets/byparken.png", "Byparken er lige stedet for udendørsmennesker. Det er er stor grøn park grænsende ned til Roskilde fjord, hvor det er perfekt at tilbringe de lange sommeraftener. Der afholdes også mange forskellige arrangementer i byparken, især om sommeren hvor der afholdes Sankt Hans, samt en hel masse spændende koncerter.", "http://www.visitroskilde.dk/danmark/byparken-roskilde-gdk619511"));
            temp.Add(new Picture("Folkeparken", "ms-appx:///Assets/Folkeparken.png", "Folkeparken er stor grøn park liggende centralt i Roskilde by. Parken er spændende at udforske, da du kan finde flere små søer, store grønne træer og et stort amfiteater. Amfiteateret er også centrum for forskellige forestillinger, hvor du f.eks. hver torsdag i sommermånederne kan opleve underholdning for de mindste. Parken bliver også brugt hver måned til motionsløb, hvor alle er velkomne til at deltage.", "http://www.visitroskilde.dk/danmark/folkeparken-roskilde-gdk619510"));
            temp.Add(new Picture("Hedeland naturpark", "ms-appx:///Assets/Hedeland.png", "Kan du lide at være aktiv, se på naturen eller bare er interesseret i at få nogle spændende oplevelser, så er Hedeland naturpark stedet for dig. På et 15 km2 stort område bygget på en gammel grusgrav, er der et hav af gå-, cykel-, ride-, motions- og naturstier, samt en golfbane, fiskesøer, en skibakke og en veteran togbane. Så hvad end du er til, så er det muligt at finde noget for dig i Hedeland naturpark.", "http://hedeland.dk/"));
            temp.Add(new Picture("Kællingehaven", "ms-appx:///Assets/Kællingehaven.png", "Hvis du vil opleve Roskilde fjord, så skal du tage til kællingehaven. Kællingehaven ligger i nærheden af Roskilde lystbådehavn, og er ideel til at opleve Roskilde fjord i alt sin pragt.", ""));
            natureGallery = new Gallery("Natur", temp);

            temp.Clear();

            temp.Add(new Picture("Vikingeskibsmuseet", "ms-appx:///Assets/Vikingeskib.png", "Vikingeskibsmuseet i Roskilde er et must see, for enhver der bare interesserer sig lidt for historie. Her kan du nemlig se fem originale vikingeskibe, og opleve skiftende særudstillinger, så selvom du har besøgt museet før, kan du stadig opleve noget nyt. Hvis du er mere til at være aktiv, kan du også sejle i et vikingeskib i Roskilde fjord, så du selv kan opleve, hvordan det var at sejle som viking.", "http://www.vikingeskibsmuseet.dk/"));
            temp.Add(new Picture("Roskilde Domkirke", "ms-appx:///Assets/Domkirkeren.png", "Roskilde domkirke er optaget på UNESCOs verdensarvsliste, og er derfor et must see imens du er i Roskilde. Domkirken har også været kongelig gravkirke i flere århundrede, og i alt hviler der 38 danske konger og dronninger i kirken. Hvis du er mere interesseret i det religiøse, så fungerer domkirken også som sognekirke, og du kan deltage i en af de mange gudtjenester, som finder sted året rundt.", "http://visit.roskildedomkirke.dk/"));
            temp.Add(new Picture("Musicon", "ms-appx:///Assets/Musicon.png", "Hvis du er interesseret i kultur, så er musicon stedet hvor det sker. Arealet hvor muscion ligger, var tidligere en betonvarefabrik, men er i dag ombygget til danseteater, kunstværksteder, skatehal, ungdomsboliger og musikøvelokaler. Med over 190 arrangementer i bydelen om året, så kan du altid finde noget at deltage i. Du kan også besøge verdens første digitale legeplads, Pixlpark, hvor du kan koble teknologi og bevægelse sammen med leg.", "http://musicon.dk/"));
            temp.Add(new Picture("Roskilde Museum", "ms-appx:///Assets/Roskilde Museum.png", "Med Danmarks største middelalder udstilling, så er Roskilde museum et sted du bare må besøge. Udstillingen består af f.eks. enestående fund fra lejre, sagnkongernes fyrstesæde og uroksen fra Himmelev Gerdrupgraven. Samtidig har Roskilde som Danmarks første hovedstad en rig historie, og denne er museet med at bringe til live. Du kan også i deltage i familieaktiviteter året rundt, så selv de mindste i familien bliver underholdt på museumsbesøget. ", "http://www.roskildemuseum.dk/"));
            temp.Add(new Picture("Ro's Torv", "ms-appx:///Assets/RosTorv.png", "Hvis du skal shoppe i Roskilde, så er Ro’s torv stedet du skal tage til. I dette unikke shoppingcenter, der ligger fokus på design, kunst og arkitektur, kan du finde 70 spændende specialbutikker, 15 spisesteder, en biograf, et fitnesscenter og 1100 parkeringspladser.", "http://rostorv.dk/forside/"));
            attractionsGallery = new Gallery("Attraktioner", temp);

            temp.Clear();

            temp.Add(new Picture("Raadhuskælderen", "ms-appx:///Assets/Kælderen.png", "Restaurant Raashuskælderen ligge i Roskildes centrum, og byder på en frokostmenu der indeholder dansk smørrebrød og a la carte retter, og en aftenmenu der står på grillretter fra lavasten, dagens fiskeret og a la carte. Hvis du kommer om sommeren, kan du endda nyde din mad i gårdhaven, der ligger mellem det gamle rådhus og domkirken.", "http://www.raadhuskaelderen.dk/index.php"));
            temp.Add(new Picture("Ilden", "ms-appx:///Assets/Ilden.png", "Ilden er en familie restaurant liggende centralt i Roskilde by, og byder på Sjællands største grillbuffet.  Ildens koncept er at alle gæster skal forlade restauranten mætte og tilfredse. Så hvis du er glad for kød, så er ilden lige for dig.", "http://ilden.dk/"));
            temp.Add(new Picture("INSP!", "ms-appx:///Assets/insp.png", "INSP! er Roskildes eneste økologiske spisested, der byder på frokost alle hverdage kl. 12 for kun 50 kr. Maden er inspireret af hele verden og laves fra bunden af årstidens økologiske råvarer. Hos INSP! er der ikke noget der hedder menukort, da maden laves i et kreativt foranderligt køkken, hvor de hele tiden udvikler ny mad.", "http://insp.dk/"));
            temp.Add(new Picture("Vigen", "ms-appx:///Assets/Vigen.png", "Restaurant Vigen byder på lækker med, som du kan nyde til byens bedste udsigt.  Aften a la carte menuen skifer hver måned, og er lavet fra bunden af de bedste råvarer, og af fagfolk der ved hvad de laver.", "http://www.vigen.dk/"));
            temp.Add(new Picture("Snekken", "ms-appx:///Assets/Snekken.png", "Snekken er med til at bringe Roskilde historie til live. Dette gør de, med hvad de kalder ny nordisk viking mad. Maden er nemlig en fusion af fortid og nutid, og består kun af råvarer som vikingerne havde adgang til.", "http://snekken.dk/"));
            restaurentsGallery = new Gallery("Restaurenter", temp);

            temp.Clear();

            temp.Add(new Picture("Gimle", "ms-appx:///Assets/Gimle.png", "Gimle er centrum i Roskildes natteliv. Gimle fungerer som spillested, ungdomskulturhus og studenterhus, og har et hav af arrangementer hele året rundt. Du kan feste natten lang i natklubben, komme til en fed koncert med din yndlings artist eller opleve et af de mange spændende foredrag. Gimle er altså stedet, hvis du vil opleve Roskilde om natten.", "http://www.gimle.dk/"));
            temp.Add(new Picture("Ip & Mary", "ms-appx:///Assets/IP.png", "IP er Roskildes mest populære ”gå i byen” sted. Hver fredag og lørdag sørger hundredevis af festglade gæster for en god aften, hvor Dj’en sørger for en god blanding af nye og gamle hits. De bryster sig også af at have Sjællands bedste barpriser. Så for en vild aften i byen, så er IP stedet.", "http://www.mary-s.dk/"));
            temp.Add(new Picture("Dansebar", "ms-appx:///Assets/PARTY.png", "Dansebar i Roskilde i stedet for dem der har lyst til at danse natten lang. Her bliver der lagt vægt på, at musikken ikke skal være technomusik der bare bumper der ud af, men i stedet musik du både kan lytte og danse til.", "http://www.dansebar.dk/"));
            temp.Add(new Picture("Garbos dansebar og Natklub", "ms-appx:///Assets/Garbos.png", "Garbos beskriver sig selv som en fusion af natklub og en trendy bar. Beliggende tæt på Roskilde station, har Garbos en god central beliggenhed, så når du er i byen om aften, er det nemt at finde derhen.", "http://www.garbos.dk/"));
            temp.Add(new Picture("Mulligans Irish Pub", "ms-appx:///Assets/Mulligans.png", "Hvis du er til rigtig pub stemning, så er Mulligans lige noget for dig. Med live musik hver fredag og lørdag hvor du kan synge med, kan aftenen kun blive god. Du kan også komme til tørstige torsdag, hvor der er billig alkohol hele natten.", "http://www.mulliganspub.dk/"));
            nightlifeGallery = new Gallery("Natteliv", temp);

            if (Userlist.CurrentUser != null && Userlist.CurrentUser.Favourites.Count > 0)
            {
                FavoriteGallery.PictureCollection = Userlist.CurrentUser.Favourites;
            }
        }

        private ICommand _userAddFavoriteCommand;
        private ICommand _userRemoveFavoriteCommand;
        private ICommand _userClearFavoritesCommand;

        public ICommand AddUserFavoritesCommand
        {
            get
            {
                if (_userAddFavoriteCommand == null)
                {
                    _userAddFavoriteCommand = new RelayCommand<Picture>(favorite => AddFavoritePicture(favorite));
                }
                return _userAddFavoriteCommand;
            }
            set { _userAddFavoriteCommand = value; }
        }

        public ICommand RemoveUserFavoriteCommand
        {
            get
            {
                if (_userRemoveFavoriteCommand == null)
                {
                    _userRemoveFavoriteCommand = new RelayCommand<Picture>(favorite => RemoveFavoritePicture(favorite));
                }
                return _userRemoveFavoriteCommand;
            }
            set { _userRemoveFavoriteCommand = value; }
        }

        public ICommand UserClearFavoritesCommand
        {
            get
            {
                if (_userClearFavoritesCommand == null)
                {
                    _userClearFavoritesCommand = new RelayCommand<ObservableCollection<Picture>>(favorites => ClearFavorites(favorites));
                }
                return _userClearFavoritesCommand;
            }
            set { _userClearFavoritesCommand = value; }
        }

        private void ClearFavorites(ObservableCollection<Picture> favorites)
        {
            favorites.Clear();
            FileHandler.Save(Userlist.ListOfUsers);
            UserMessageHandler myMessageHandler = new UserMessageHandler("Favoritter er blevet ryddet", "Favoritter ryddet");
            myMessageHandler.Show();
        }

        private void RemoveFavoritePicture(Picture favoritePicture)
        {
            User currentUser = Userlist.UserlistInstance.CurrentUser;
            

            if (currentUser.Favourites.Contains(favoritePicture))
            {
                UserMessageHandler myMessageHandler = new UserMessageHandler(favoritePicture.Name + " er blevet fjernet fra dine favoritter", "Favorit fjernet");
                myMessageHandler.Show();

                currentUser.RemoveFavourite(favoritePicture);
                FileHandler.Save(Userlist.ListOfUsers);
            }
            else
            {
                UserMessageHandler myMessageHandler = new UserMessageHandler(favoritePicture.Name + " findes ikke i dine favoritter", "Favorit findes ikke");
                myMessageHandler.Show();
            }
        }

        private void AddFavoritePicture(Picture favoritePicture)
        {
            User currentUser = Userlist.UserlistInstance.CurrentUser;

            if (currentUser.Favourites.Contains(favoritePicture))
            {
                UserMessageHandler myMessageHandler = new UserMessageHandler(favoritePicture.Name + " findes allerede som favorit", "Favorit findes allerede");
                myMessageHandler.Show();
            }
            else
            {
                if (currentUser.Favourites.Count < 5)
                {
                    currentUser.AddFavourite(favoritePicture);
                    FileHandler.Save(Userlist.ListOfUsers);
                    UserMessageHandler myMessageHandler =
                        new UserMessageHandler(favoritePicture.Name + " er tilføjet til din favorit liste",
                            "Favorit tilføjet");
                    myMessageHandler.Show();
                }
                else
                {
                    UserMessageHandler myMessageHandler = new UserMessageHandler("Du har nået maks favoritter", "Favorit maximum nået");
                    myMessageHandler.Show();
                }
            }
            
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
