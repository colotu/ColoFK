using ServiceStack.DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using ServiceStack.Common.Web;

namespace YSWL.RedisClient
{
    /// <summary>
    /// redis扩展
    /// </summary>
    public static class RedisExtensionsExt
    {
        public static string[] GetIds(this IHasStringId[] itemsWithId)
        {
            string[] strArray = new string[itemsWithId.Length];
            for (int i = 0; i < itemsWithId.Length; i++)
            {
                strArray[i] = itemsWithId[i].Id;
            }
            return strArray;
        }

        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return (!socket.Poll(1, SelectMode.SelectRead) || (socket.Available != 0));
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public static List<RedisEndpoint> ToIpEndPoints(this IEnumerable<string> hosts)
        {
            if (hosts == null)
            {
                return new List<RedisEndpoint>();
            }
            List<RedisEndpoint> list = new List<RedisEndpoint>();
            foreach (string str in hosts)
            {
                if (str.Contains("@"))
                {
                    string[] hostParts = str.Split(new char[] { '@' });
                    var password = hostParts[0];
                    hostParts = hostParts[1].Split(':');
                    int port = (hostParts.Length == 1) ? 0x18eb : int.Parse(hostParts[1]);
                    RedisEndpoint item = new RedisEndpoint(hostParts[0], port, password);
                    list.Add(item);
                }
                else
                {
                    string[] strArray = str.Split(new char[] { ':' });
                    if (strArray.Length == 0)
                    {
                        throw new ArgumentException("'{0}' is not a valid Host or IP Address: e.g. '127.0.0.0[:11211]'");
                    }
                    int port = (strArray.Length == 1) ? 0x18eb : int.Parse(strArray[1]);
                    RedisEndpoint item = new RedisEndpoint(strArray[0], port);
                    list.Add(item);
                }
            }
            return list;
        }

        public static List<string> ToStringList(this byte[][] multiDataList)
        {
            if (multiDataList == null)
            {
                return new List<string>();
            }
            List<string> list = new List<string>();
            foreach (byte[] buffer in multiDataList)
            {
                list.Add(buffer.FromUtf8Bytes());
            }
            return list;
        }
    }

    public class RedisEndpoint 
    {
        public RedisEndpoint(string host, int port, string password = null, long db = 1)
        {
            this.Host = host;
            this.Port = port;
            this.Password = password;
            this.Db = db;
        }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public int ConnectTimeout { get; set; }
        public int SendTimeout { get; set; }
        public int ReceiveTimeout { get; set; }
        public int RetryTimeout { get; set; }
        public int IdleTimeOutSecs { get; set; }
        public long Db { get; set; }
        public string Client { get; set; }
        public string Password { get; set; }
        public bool RequiresAuth { get { return !string.IsNullOrEmpty(Password); } }
        public string NamespacePrefix { get; set; }
        protected bool Equals(RedisEndpoint other)
        {
            return string.Equals(Host, other.Host)
            && Port == other.Port
            && Ssl.Equals(other.Ssl)
            && ConnectTimeout == other.ConnectTimeout
            && SendTimeout == other.SendTimeout
            && ReceiveTimeout == other.ReceiveTimeout
            && RetryTimeout == other.RetryTimeout
            && IdleTimeOutSecs == other.IdleTimeOutSecs
            && Db == other.Db
            && string.Equals(Client, other.Client)
            && string.Equals(Password, other.Password)
            && string.Equals(NamespacePrefix, other.NamespacePrefix);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RedisEndpoint)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Host != null ? Host.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Port;
                hashCode = (hashCode * 397) ^ Ssl.GetHashCode();
                hashCode = (hashCode * 397) ^ ConnectTimeout;
                hashCode = (hashCode * 397) ^ SendTimeout;
                hashCode = (hashCode * 397) ^ ReceiveTimeout;
                hashCode = (hashCode * 397) ^ RetryTimeout;
                hashCode = (hashCode * 397) ^ IdleTimeOutSecs;
                hashCode = (hashCode * 397) ^ Db.GetHashCode();
                hashCode = (hashCode * 397) ^ (Client != null ? Client.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NamespacePrefix != null ? NamespacePrefix.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
