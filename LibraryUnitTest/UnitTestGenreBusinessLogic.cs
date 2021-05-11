using System;
using System.Collections.Generic;
using ConsoleLibrary.DataEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{

    public abstract class UnitTestGenreBusinessLogicBase
    {
        static private readonly object _businesLogic;
        static private object p1;

        //public abstract UnitTestGenreBusinessLogic_conn ();
        public override bool Equals(object obj)
        {
            return Equals(obj as UnitTestGenreBusinessLogicBase);
        }

        public static bool operator ==(UnitTestGenreBusinessLogicBase left, UnitTestGenreBusinessLogicBase right)
        {
            return EqualityComparer<UnitTestGenreBusinessLogicBase>.Default.Equals(left, right);
        }

        public static bool operator !=(UnitTestGenreBusinessLogicBase left, UnitTestGenreBusinessLogicBase right)
        {
            return !(left == right);
        }
    }
}