string[] answer;
//string[][] accounts;// = new List<string[][]>();

string[] solution(string[][] queries) {
    answer = new string[queries.Length];
    var accounts = new List<account>();
    //accounts = new string[queries.Length][2]();
    
    
    string CREATE_ACCOUNT(string timestamp,string accountId)
    {
        if (accounts.Count > 0 && accounts.Exists( c => c.id == accountId))
        {
            return "false";
        }
        
        account newAccount = new account { id = accountId , ts = timestamp , saldo = 0};
        
        return "true";
        
        
    }
    
    string DEPOSIT (string timestamp,string accountId, double amount)
    {
         if (accounts.Count > 0 && accounts.Exists( c => c.id == accountId))
        {
            account a = accounts.Find( c=> c.id == accountId);
            a.saldo += amount;
            return a.saldo.ToString();
        }
        
        return "";
    }
    
    string TRANSFER(string timestamp, string sourceAccountId, string targetAccountId, double amount)
    {
         if (accounts.Count > 0 && accounts.Exists( c => c.id == sourceAccountId) && accounts.Exists( c => c.id == targetAccountId))
        {
            account source = accounts.Find( c=> c.id == sourceAccountId);
            source.saldo -= amount;
            account target = accounts.Find( c=> c.id == targetAccountId);
            target.saldo += amount;
            
            
            return source.saldo.ToString();
        }
        
        
        return "";
    }
    
    for (int i=0;i<queries.Length;i++)
    {
        if(queries[i][0].Equals("CREATE_ACCOUNT"))
        {
            answer[i] = CREATE_ACCOUNT(queries[i][1],queries[i][2]);
            
            
        }
        else
        {
            if(queries[i][0].Equals("DEPOSIT"))
            {
                answer[i] = DEPOSIT(queries[i][1],queries[i][2],Double.Parse(queries[i][3]));
            }
            else
            {
                //if(queries[i][0].Equals("TRANSFER"))
                //{
                    answer[i] = TRANSFER(queries[i][1],queries[i][2],queries[i][3],Double.Parse(queries[i][4]));
                //}
            }
            
        }
        
    }


}

public class account
{
    public string id;
    public string ts;
    public double saldo;
}