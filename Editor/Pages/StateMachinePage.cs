namespace Invert.uFrame.MVVM {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class StateMachinePage : StateMachinePageBase {
        public override string Name
        {
            get { return "State Machines"; }
        }

        public override void GetContent(Invert.Core.GraphDesigner.IDocumentationBuilder _) {
            base.GetContent(_);
        }
    }
}
