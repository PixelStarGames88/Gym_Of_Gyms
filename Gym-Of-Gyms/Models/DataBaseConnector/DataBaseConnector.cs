using Gym_Of_Gyms.Models.DataBaseModels;
using Supabase.Postgrest.Models;

namespace Gym_Of_Gyms.Models.DataBaseConnector;

public class DataBaseConnector
{
    Supabase.Client supabase;

    public DataBaseConnector(IConfiguration configuration)
    {
        var supabaseURl = configuration.GetConnectionString("UrlConnection") ?? throw new NullReferenceException();
        var supabaseKey = configuration.GetConnectionString("KeyConnection") ?? throw new NullReferenceException();

        supabase = new Supabase.Client(supabaseURl, supabaseKey);
    }
    private async void GetConnection()
    {
        await supabase.InitializeAsync();
    }
    public async Task<UserGymModel?> CreateAccount(string login, string password, string firstName, string lastName, string fatherName, double weight, double height)
    {
        try
        {
            GetConnection();
            var UserGym = new UserGymModel
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                FatherName = fatherName,
                Weight = weight,
                Height = height
            };
            await supabase.From<UserGymModel>().Insert(UserGym);

            return UserGym;
        }
        catch
        {
            return null;
        }
    }
    public async Task<UserGymModel?> EnterToAccount(string login, string password)
    {
        try
        {
            GetConnection();
            var UserGyms = await supabase.From<UserGymModel>().Where(x => x.Login == login && x.Password == password).Get();
            return UserGyms.Models.FirstOrDefault();
        }
        catch
        {
            return null;
        }
    }
}