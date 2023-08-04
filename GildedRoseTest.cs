using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        // Helper method to check if an item exists in the list of items
        private bool ItemExists(IList<Item> items, string name)
        {
            foreach (var item in items)
            {
                if (item.Name == name)
                    return true;
            }
            return false;
        }

        // Helper method to get an item by its name from the list of items
        private Item GetItem(IList<Item> items, string name)
        {
            foreach (var item in items)
            {
                if (item.Name == name)
                    return item;
            }
            return null;
        }

        [Test]
        // Normal item quality should decrease by one after updating.
        public void NormalItemQualityDecreasesByOne()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(19, GetItem(items, "+5 Dexterity Vest").Quality);
        }

        [Test]
        // Normal item SellIn (days to sell) should decrease by one after updating.
        public void NormalItemSellInDecreasesByOne()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(9, GetItem(items, "+5 Dexterity Vest").SellIn);
        }

        [Test]
        // Normal item quality degrades twice as fast after SellIn (days to sell) becomes negative.
        public void NormalItemQualityDegradesTwiceAsFastAfterSellIn()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(18, GetItem(items, "+5 Dexterity Vest").Quality);
        }

        [Test]
        // Aged Brie quality increases by one after updating.
        public void AgedBrieQualityIncreasesByOne()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(1, GetItem(items, "Aged Brie").Quality);
        }

        [Test]
        // Aged Brie quality increases twice as fast after SellIn (days to sell) becomes negative.
        public void AgedBrieQualityIncreasesTwiceAsFastAfterSellIn()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(2, GetItem(items, "Aged Brie").Quality);
        }

        [Test]
        // Quality of an item should never exceed 50.
        public void QualityNeverExceedsFifty()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(50, GetItem(items, "Aged Brie").Quality);
        }

        [Test]
        // Sulfuras quality never changes after updating.
        public void SulfurasQualityNeverChanges()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(80, GetItem(items, "Sulfuras, Hand of Ragnaros").Quality);
        }

        [Test]
        // Backstage Pass quality increases by one after updating.
        public void BackstagePassQualityIncreasesByOne()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(21, GetItem(items, "Backstage passes to a TAFKAL80ETC concert").Quality);
        }

        [Test]
        // Backstage Pass quality increases by two when SellIn (days to sell) is ten or less.
        public void BackstagePassQualityIncreasesByTwoWhenSellInIsTenOrLess()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(22, GetItem(items, "Backstage passes to a TAFKAL80ETC concert").Quality);
        }

        [Test]
        // Backstage Pass quality increases by three when SellIn (days to sell) is five or less.
        public void BackstagePassQualityIncreasesByThreeWhenSellInIsFiveOrLess()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(23, GetItem(items, "Backstage passes to a TAFKAL80ETC concert").Quality);
        }

        [Test]
        // Backstage Pass quality drops to zero after the concert (SellIn becomes negative).
        public void BackstagePassQualityDropsToZeroAfterConcert()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, GetItem(items, "Backstage passes to a TAFKAL80ETC concert").Quality);
        }

        [Test]
        // Conjured item quality decreases by two after updating.
        public void ConjuredItemQualityDecreasesByTwo()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(4, GetItem(items, "Conjured Mana Cake").Quality);
        }

        [Test]
        // Conjured item quality degrades twice as fast after SellIn (days to sell) becomes negative.
        public void ConjuredItemQualityDegradesTwiceAsFastAfterSellIn()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 6 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(2, GetItem(items, "Conjured Mana Cake").Quality);
        }

        [Test]
        // Conjured item quality never drops below zero.
        public void ConjuredItemQualityNeverDropsBelowZero()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 1 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, GetItem(items, "Conjured Mana Cake").Quality);
        }

        [Test]
        // Non-existing item should be removed from the list after updating.
        public void NonExistingItemDoesNotExistAfterUpdate()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Non-existing Item", SellIn = 3, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.IsFalse(ItemExists(items, "Non-existing Item"));
        }
    }
}
