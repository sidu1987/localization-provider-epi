// Copyright (c) Valdis Iljuconoks. All rights reserved.
// Licensed under Apache-2.0. See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;

namespace DbLocalizationProvider.EPiServer
{
    public class LocalizedEnumSelectionFactory<TEnum> : ISelectionFactory where TEnum : struct
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var values = Enum.GetValues(typeof(TEnum))
                             .Cast<Enum>();

            foreach(var value in values)
            {
                yield return new SelectItem
                             {
                                 Text = value.Translate(),
                                 Value = value
                             };
            }
        }
    }
}
