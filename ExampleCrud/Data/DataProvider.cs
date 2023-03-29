using System.Data.SqlClient;
using Dapper;
using ExampleCrud.Models;

namespace ExampleCrud.Data;

public class DataProvider
{
    private const string ConnStr = "Server=DESKTOP-IFN84LU\\SQLEXPRESS01;Database=Lab1;Trusted_Connection=True;";
    public DataProvider(){}
    
    public Task<List<Car>> GetCars(string dbName)
    {
        List<Car> results;
        const string sql = "SELECT Car AS CarDesc, MilesPerGallon AS Mpg FROM [dbo].[Cars]";
        using SqlConnection conn = new(ConnStr);
        try
        {
            conn.Open();
            conn.ChangeDatabase(dbName);
            results = conn.Query<Car>(sql).ToList();
            
            return Task.FromResult(results);
        }
        catch (Exception e)
        {
            results = new List<Car>();
        }
        return Task.FromResult(results);
    }


    public Task<List<EnergyConsumption>> GetConsumption(string db)
    {
        List<EnergyConsumption> results;
        const string sql = "SELECT * FROM dbo.EnergyConsumption";
        using SqlConnection conn = new(ConnStr);
        try
        {
            conn.Open();
            conn.ChangeDatabase(db);
            results = conn.Query<EnergyConsumption>(sql).ToList();
            
            return Task.FromResult(results);
        }
        catch (Exception e)
        {
            results = new List<EnergyConsumption>();
        }
        return Task.FromResult(results);
    }

    public List<double> GetRandomNumbers(string db)
    {
        List<double> results = new();
        string sql = @"SELECT FLOOR(RAND()*(1000-5)+5) AS Num;";
        using SqlConnection conn = new(ConnStr);
        try
        {
            conn.Open();
            conn.ChangeDatabase(db);
            for (int i = 0; i < 8; i++)
            {
                double num = conn.QueryFirst<double>(sql);
                results.Add(num);
            }
        }
        catch (Exception e)
        {
            results = new List<double>();
        }

        return results;
    }
}