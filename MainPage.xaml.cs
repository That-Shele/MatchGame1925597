namespace MatchGame1925597
{
    public partial class MainPage : ContentPage
    {
        //Se declara una interfaz de tipo DispatcherTimer
        IDispatcherTimer timer;
        //Se delcaran variables para los milisegundos y las parejas
        int miliseconds;
        int pairs;

        //Se inicializa la página
        public MainPage()
        {
            //Se crea el temporizador
            timer = Dispatcher.CreateTimer();
            //Se inicializa la funcionalidad de la página
            InitializeComponent();
            //Se declara el inicio del temporizador desde el primer milisegundo
            timer.Interval = TimeSpan.FromSeconds(.1);
            //Se declara el contról de ticks del temporizador
            timer.Tick += Timer_Tick;
            //Se inicializa la funcionalidad del juego
            setupGame();
        }

        //Control de ticks del temporizador
        private void Timer_Tick(object? sender, EventArgs e)
        {
            //Por cada tick se suma un milisegundo
            miliseconds++;
            //Se muestran en pantalla los milisegundos
            txtTimer.Text = (miliseconds / 10f).ToString("0.00s");
            //Si los pares encontrados equivalen a 8...
            if (pairs == 8)
            {
                //Se para el temporizador
                timer.Stop();
                //Se cambia el texto del temporizador
                txtTimer.Text = txtTimer.Text + " - ¿Jugar de nuevo?";
                //Se habilita el botón para reiniciar
                btnRestart.IsVisible = true;
            }
        }

        //Al hacer clic en el botón de reiniciar
        private void btnRestart_Clicked(object sender, EventArgs e)
        {
            //Se inicializa la configuración del juego
            setupGame();
            //El botón de reinicio se deshabilita
            btnRestart.IsVisible = false;
        }

        //Configuración del juego
        private void setupGame()
        {
            //Se declara una lista con todos los caractéres a mostrar
            List<string> animalEmoji = new List<string>()
            {
                "🐶","🐶",
                "🐵","🐵",
                "🐱","🐱",
                "🦒","🦒",
                "🦊","🦊",
                "🐭","🐭",
                "🐻","🐻",
                "🐷","🐷",
            };
            //Se instancia un objeto de tipo aleatorio
            Random random = new Random();
            //Se hace un repaso por cada botón en el grid
            foreach (Button view in Grid1.Children)
            {
                //Se habilita su visibilidad
                view.IsVisible = true;
                //Se obtiene un índice que equivale a una posición aleatoria en
                //la lista de caractéres
                int index = random.Next(animalEmoji.Count);
                //Se asigna ese índice a un emoji de la lista y se guarda en una variable
                string nextEmoji = animalEmoji[index];
                //Se visualiza ese emoji en el botón
                view.Text = nextEmoji;
                //Se elimina el emoji de la lista para evitar repeticiones no deseadas
                animalEmoji.RemoveAt(index);
            }
            //Inicia el temporizador, con milisegundos y pares en cero
            timer.Start();
            miliseconds = 0;
            pairs = 0;
            
        }

        //Se declara variable de tipo botón para guardar el útimo botón pulsado
        Button ultimoButtonClicked;
        //Se declara variable para encontrar las parejas
        bool encontrandoMatch = false;
        
        //Al hacer clic en un botón que contenga este evento...
        private void Button_Clicked(object sender, EventArgs e)
        {
            //Se guarda la acción en un valor de tipo botón
            Button button = sender as Button;
            //Al hacer clic en un botón, si esta variable está en false...
            if (encontrandoMatch == false)
            {
                //Invisibilizar el botón
                button.IsVisible = false;
                //Guardar este botón en la variable
                ultimoButtonClicked = button;
                //Cambiar el estado de encontrandomatch a true
                encontrandoMatch = true;
            }
            //Si el siguiente botón coincide con el útlimo botón...
            else if (button.Text == ultimoButtonClicked.Text)
            {
                //Añadir uno a los pares encontrados
                pairs++;
                //Invisivilizar este botón
                button.IsVisible = false;
                //Cambiar el estado de encontrandomatch a false
                encontrandoMatch = false;
            }
            //Si no coincide...
            else
            {
                //Devolver visibilidad al último botón
                ultimoButtonClicked.IsVisible = true;
                //Cambiar el estado de encontrandomatch a false
                encontrandoMatch = false;
            }
        }

        
    }

}
