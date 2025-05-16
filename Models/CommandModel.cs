using System.Collections.Generic;


namespace TradeExec.Models
{
    public static class CommandModel
    {
        public static Dictionary<string, string> CreateOrder(string sym, string side, int qty, string account, string cid = null)
        {
            var dict = new Dictionary<string, string>
            {
                { "type", "order" },
                { "sym", sym },
                { "side", side.ToLowerInvariant() },
                { "qty", qty.ToString() },
                { "account", account }
            };

            if (!string.IsNullOrWhiteSpace(cid))
                dict["cid"] = cid;

            return dict;
        }

        public static Dictionary<string, string> CreateCancel(string cid)
        {
            return new Dictionary<string, string>
            {
                { "type", "cancel" },
                { "cid", cid }
            };
        }

        public static Dictionary<string, string> CreateCancelAll(string account)
        {
            return new Dictionary<string, string>
            {
                { "type", "cancelall" },
                { "account", account }
            };
        }

        public static Dictionary<string, string> CreateFlatten(string account)
        {
            return new Dictionary<string, string>
            {
                { "type", "flatten" },
                { "account", account }
            };
        }

        public static Dictionary<string, string> CreateQueryAcct(params string[] accounts)
        {
            string accountValue;

            if (accounts.Length == 1 && accounts[0] == "*")
            {
                accountValue = "*";
            }
            else
            {
                var clean = accounts
                    .Where(a => !string.IsNullOrWhiteSpace(a))
                    .Select(a => a.Trim())
                    .Distinct();

                accountValue = string.Join(",", clean);
            }

            return new Dictionary<string, string>
    {
        { "type", "queryAcct" },
        { "account", accountValue }
    };
        }
    }
}