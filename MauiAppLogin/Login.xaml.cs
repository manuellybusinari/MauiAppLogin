namespace MauiAppLogin;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<Dadosdousuario> lista_usuarios = new List<Dadosdousuario>()
            {
                new Dadosdousuario()
                {
                    Usuario = "jose",
                    Senha = "123"
                },
                new Dadosdousuario()
                {
                    Usuario = "maria",
                    Senha = "321"
                }
            };

            Dadosdousuario dados_digitados = new Dadosdousuario()
            {
                Usuario = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            // LINQ
            bool encontrou = lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha));

            if (encontrou)
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protegida();

            }
            else
            {
                throw new Exception("Usuário ou senha incorretos.");
            }


        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}