﻿using System.Collections.Generic;
using Value;

namespace SeatsSuggestions.Domain
{
    public class SuggestionRequest : ValueType<SuggestionRequest>
    {
        public int PartyRequested { get; }
        public PricingCategory PricingCategory { get; }

        public SuggestionRequest(int partyRequested, PricingCategory pricingCategory)
        {
            PartyRequested = partyRequested;
            PricingCategory = pricingCategory;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new object[] {PartyRequested, PricingCategory};
        }

        public override string ToString()
        {
            return $"{PartyRequested}-{PricingCategory.ToString()}";
        }
    }
}