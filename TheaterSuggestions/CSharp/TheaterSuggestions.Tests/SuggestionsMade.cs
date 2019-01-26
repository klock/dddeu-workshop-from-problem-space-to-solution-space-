﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SeatsSuggestions.Tests
{
    /// <summary>
    ///     Occurs when a bunch of Suggestion are made.
    /// </summary>
    public class SuggestionsMade
    {
        public string ShowId { get; }
        public int PartyRequested { get; }

        public Dictionary<PricingCategory, List<SuggestionMade>> ForCategory { get; } =
            new Dictionary<PricingCategory, List<SuggestionMade>>();

        public SuggestionsMade(string showId, int partyRequested)
        {
            ShowId = showId;
            PartyRequested = partyRequested;

            InstantiateAnEmptyListForEveryPricingCategory();
        }

        public IReadOnlyList<SuggestionMade> GetSuggestionsFor(PricingCategory pricingCategory)
        {
            return ForCategory[pricingCategory];
        }

        public IEnumerable<string> SeatNames(PricingCategory pricingCategory)
        {
            return ForCategory[pricingCategory].SelectMany(s => s.SeatNames());
        }

        private void InstantiateAnEmptyListForEveryPricingCategory()
        {
            foreach (PricingCategory pricingCategory in Enum.GetValues(typeof(PricingCategory)))
            {
                ForCategory[pricingCategory] = new List<SuggestionMade>();
            }
        }

        public void Add(IEnumerable<SuggestionMade> suggestions)
        {
            foreach (var suggestionMade in suggestions)
            {
                ForCategory[suggestionMade.PricingCategory].Add(suggestionMade);
            }
        }

        public bool MatchExpectations()
        {
            return ForCategory.SelectMany(s => s.Value).Any(x => x.MatchExpectation());
        }
    }
}