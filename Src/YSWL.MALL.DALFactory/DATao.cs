using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.DALFactory
{
    public class DATao : DataAccessBase
    {
        public static YSWL.MALL.IDAL.Tao.ICategory CreateCategory()
        {
            string ClassNamespace = AssemblyPath + ".Tao.Category";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.ICategory)objType;
        }

        public static YSWL.MALL.IDAL.Tao.ICategorySource CreateCategorySource()
        {
            string ClassNamespace = AssemblyPath + ".Tao.CategorySource";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.ICategorySource)objType;
        }

        public static YSWL.MALL.IDAL.Tao.IProduct CreateProduct()
        {
            string ClassNamespace = AssemblyPath + ".Tao.Product";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IProduct)objType;
        }

        public static YSWL.MALL.IDAL.Tao.IReport CreateReport()
        {
            string ClassNamespace = AssemblyPath + ".Tao.Report";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IReport)objType;
        }

        public static YSWL.MALL.IDAL.Tao.IShop CreateShop()
        {
            string ClassNamespace = AssemblyPath + ".Tao.Shop";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IShop)objType;
        }

        public static YSWL.MALL.IDAL.Tao.IShopCategory CreateShopCategory()
        {
            string ClassNamespace = AssemblyPath + ".Tao.ShopCategory";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IShopCategory)objType;
        }

        public static YSWL.MALL.IDAL.Tao.IShopCateSource CreateShopCateSource()
        {
            string ClassNamespace = AssemblyPath + ".Tao.ShopCateSource";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IShopCateSource)objType;
        }

        public static YSWL.MALL.IDAL.Tao.IUserInvite CreateUserInvite()
        {
            string ClassNamespace = AssemblyPath + ".Tao.UserInvite";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IUserInvite)objType;
        }


        public static YSWL.MALL.IDAL.Tao.IBalanceDetails CreateBalanceDetails()
        {
            string ClassNamespace = AssemblyPath + ".Tao.BalanceDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.Tao.IBalanceDetails)objType;
        }


    }
}
