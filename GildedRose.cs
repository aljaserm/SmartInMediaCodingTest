using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                // Legendary item "Sulfuras" never decreases in Quality and does not have to be sold.
                if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                // Decrease the Quality for normal items (not "Aged Brie", "Backstage passes", or "Conjured Mana Cake")
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Conjured Mana Cake")
                {
                    if (Items[i].Quality > 0)
                    {
                        // Decrease Quality by 1 for normal items before SellIn date
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
                else // Handle "Aged Brie", "Backstage passes", and "Conjured Mana Cake"
                {
                    if (Items[i].Quality < 50) // Ensure Quality does not exceed 50
                    {
                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn <= 0)
                            {
                                // Quality drops to 0 after the concert
                                Items[i].Quality = 0;
                            }
                            else if (Items[i].SellIn <= 5)
                            {
                                // Quality increases by 3 when there are 5 days or less until the concert
                                Items[i].Quality = Items[i].Quality + 3;
                            }
                            else if (Items[i].SellIn <= 10)
                            {
                                // Quality increases by 2 when there are 10 days or less until the concert
                                Items[i].Quality = Items[i].Quality + 2;
                            }
                            else
                            {
                                // Quality increases by 1 before 10 days until the concert
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                        else if (Items[i].Name == "Aged Brie")
                        {
                            // "Aged Brie" increases in Quality as it gets older
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                        else if (Items[i].Name == "Conjured Mana Cake")
                        {
                            // "Conjured" items degrade in Quality twice as fast as normal items
                            // Decrease quality by 2 if sellIn is positive, and decrease by 4 if sellIn is negative
                            if (Items[i].SellIn > 0)
                            {
                                Items[i].Quality = Items[i].Quality - 2;
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - 4;
                            }
                        }

                        // Ensure quality does not exceed 50
                        if (Items[i].Quality > 50)
                        {
                            Items[i].Quality = 50;
                        }
                    }
                }

                // SellIn value decreases for all items except "Sulfuras"
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                // Once the sell by date has passed, Quality degrades twice as fast
                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Name != "Conjured Mana Cake")
                        {
                            if (Items[i].Quality > 0)
                            {
                                // Decrease Quality by 1 for normal items after the sell by date
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                        else
                        {
                            // "Conjured" items degrade in Quality twice as fast as normal items
                            Items[i].Quality = Items[i].Quality - 2;
                        }
                    }
                    else
                    {
                        if (Items[i].Name == "Aged Brie")
                        {
                            // "Aged Brie" increases in Quality even after the sell by date
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                        else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            // Quality drops to 0 after the concert
                            Items[i].Quality = 0;
                        }
                    }
                }
            }
        }
    }
}
