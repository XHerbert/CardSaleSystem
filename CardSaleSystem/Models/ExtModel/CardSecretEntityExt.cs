using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XHB.Card.Entity;

namespace XHB.Card.Entity
{
    public class CardSecretEntityExt
    {
        public IList<CardSecretEntity> CardSecretEntity { get; set; }

        public IList<ActTypeEntity> ActTypeEntity { get; set; }
    }
}