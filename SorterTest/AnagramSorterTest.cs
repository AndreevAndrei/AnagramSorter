using Microsoft.VisualStudio.TestTools.UnitTesting;
using SorterNS;
using System.Collections.Generic;

namespace SorterTest
{
    [TestClass]
    public class AnagramSorterTest
    {
        /// <summary>
        /// Простой тест слов из 3-х букв
        /// </summary>
        [TestMethod]
        public void SimpleTest()
        {
            var words = new string[] { "dog", "cat", "rat", "pet", "god" };
            var rightAnswer = "[\r\n\t[\"dog\", \"god\"]\r\n\t[\"cat\"]\r\n\t[\"rat\"]\r\n\t[\"pet\"]\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }

        /// <summary>
        /// Полная пустота
        /// </summary>
        [TestMethod]
        public void EmptyTest()
        {
            var words = new string[] {  };
            var rightAnswer = "[\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }

        /// <summary>
        /// Расширенный тест с пустыми строками, цифрами, символами и спец.символами
        /// </summary>
        [TestMethod]
        public void ExtendedTest()
        {
            // }|{u3Hb
            var words = new string[] { "!@#$%^&*(){}", "}{)(*&^%$#@!", "", "|/~\r\n\\", "\\\r\n~/|", ";:,.", "<>№?*`", "123", "231", "321", "133" };
            var rightAnswer = "[\r\n\t[\"!@#$%^&*(){}\", \"}{)(*&^%$#@!\"]\r\n\t[\"\"]\r\n\t[\"|/~\r\n\\\", \"\\\r\n~/|\"]\r\n\t[\";:,.\"]\r\n\t[\"<>№?*`\"]\r\n\t[\"123\", \"231\", \"321\"]\r\n\t[\"133\"]\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }


        /// <summary>
        /// Слова с пробелами и повторяющиеся слова
        /// </summary>
        [TestMethod]
        public void WhiteSpaceOrDuplicateTest()
        {
            // В данной реализации "ко т" и "ток" будут разными словами. То есть white-space символы
            // игнорируются, так как в данной задаче, может скобки/ковычки (и др.) надо так же игнорировать.
            // Например, если надо чтобы "(кот)" = "кот", то необходимо доработать логику AnagramSorter.Group.
            var words = new string[] { "ко т", "ток", "отк ", "\t ", " \t ", "  ", "  ", "ток" };
            var rightAnswer = "[\r\n\t[\"ко т\", \"отк \"]\r\n\t[\"ток\", \"ток\"]\r\n\t[\"\t \"]\r\n\t[\" \t \"]\r\n\t[\"  \", \"  \"]\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }

        /// <summary>
        /// Разноязычные слова
        /// </summary>
        [TestMethod]
        public void MultilanguageTest()
        {
            var words = new string[] { "cat", "кот", "кiт", "Der Kater", "貓", "靠窗的猫", "的窗猫靠", "tac", "kit", "Ker Dater" };
            var rightAnswer = "[\r\n\t[\"cat\", \"tac\"]\r\n\t[\"кот\"]\r\n\t[\"кiт\"]\r\n\t[\"Der Kater\", \"Ker Dater\"]\r\n\t[\"貓\"]\r\n\t[\"靠窗的猫\", \"的窗猫靠\"]\r\n\t[\"kit\"]\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }

        /// <summary>
        /// Транслит
        /// </summary>
        [TestMethod]
        public void TransliterationTest()
        {
            // В данной реализации "cat", "кот" и "kot" - разные слова. Если какие-то из этих примером
            // желательно догруппировать, то необходимо доработать логику AnagramSorter.Group.
            var words = new string[] { "KoT", "кОт", "}|{u3Hb", "Жизнь", "TpaHcJlT", "транслит", "prostoy_translit", "простой_транслит" };
            var rightAnswer = "[\r\n\t[\"KoT\"]\r\n\t[\"кОт\"]\r\n\t[\"}|{u3Hb\"]\r\n\t[\"Жизнь\"]\r\n\t[\"TpaHcJlT\"]\r\n\t[\"транслит\"]\r\n\t[\"prostoy_translit\"]\r\n\t[\"простой_транслит\"]\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }

        /// <summary>
        /// Много длинных слов (для примера 100 слов из более 20-и+ букв)
        /// </summary>
        [TestMethod]
        public void LoadTest()
        {
            var words = new string[] { "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "testtexttesttexttesttext", "extrabigtextwithmanysymbolsfortest", "abcdefghijklmnopqrstuvwxyz", "qwertyqwertyqwertyqwertyqwerty", "asdlkjasdlkjasdlkjasdkljasdlkj" };
            var rightAnswer = "[\r\n\t[\"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\", \"extrabigtextwithmanysymbolsfortest\"]\r\n\t[\"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\", \"abcdefghijklmnopqrstuvwxyz\"]\r\n\t[\"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\", \"qwertyqwertyqwertyqwertyqwerty\"]\r\n\t[\"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\", \"asdlkjasdlkjasdlkjasdkljasdlkj\"]\r\n\t[\"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\", \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"]\r\n\t[\"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\", \"testtexttesttexttesttext\"]\r\n]";

            var result = AnagramSorter.Group(words);
            var testAnswer = AnagramSorter.ToString(result);
            Assert.AreEqual(testAnswer, rightAnswer);
        }
        
    }
}
