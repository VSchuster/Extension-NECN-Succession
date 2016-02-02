//  Copyright 2007-2010 Portland State University, University of Wisconsin-Madison
//  Author: Robert Scheller, Ben Sulman

using Landis.Core;
using Landis.SpatialModeling;
using Landis.Library.LeafBiomassCohorts;
using System.Collections.Generic;


namespace Landis.Extension.Succession.Century
{
    public class LitterType
    {
        public double DecayRateStrucC;
        public double DecayRateMetabolicC;
        public double DecayRateMicrobes;


        //---------------------------------------------------------------------

        public LitterType()
        {
            this.DecayRateStrucC = 0.0;
            this.DecayRateMetabolicC = 0.0;
            this.DecayRateMicrobes = 0.0;
        }
    }
}
