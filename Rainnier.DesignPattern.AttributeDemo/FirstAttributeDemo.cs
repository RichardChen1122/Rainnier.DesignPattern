using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.AttributeDemo
{
    [Flags]
    internal enum Accounts
    {
        Savings = 0x0001,
        Checking = 0x0002,
        Brokerage = 0x0004
    }

    internal sealed class AccountsAttribute : Attribute
    {
        private Accounts m_accounts;
        public AccountsAttribute()
        {

        }

        public AccountsAttribute(Accounts accounts)
        {
            this.m_accounts = accounts;
        }

        public override bool Match(object obj)
        {
            //由于this 不为null， 如果obj=null，那么对象肯定不相等
            if (obj == null)
            {
                return false;
            }

            //如果对象的类型不一样，则肯定不相等
            if (this.GetType() != obj.GetType()) return false;

            AccountsAttribute other = (AccountsAttribute)obj;
            if ((other.m_accounts & m_accounts) != m_accounts)
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType()) return false;

            AccountsAttribute other = (AccountsAttribute)obj;
            if ((other.m_accounts & m_accounts) != m_accounts)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return (int)m_accounts;
        }
    }

    [Accounts(Accounts.Savings)]
    internal sealed class ChildAccount
    {

    }

    [Accounts(Accounts.Savings | Accounts.Checking | Accounts.Brokerage)]
    internal sealed class AdultAccount
    {

    }
}
