// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Matze {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS.APIs;
    using uFrame.ECS.Components;
    using uFrame.ECS.Systems;
    using uFrame.Kernel;
    using UniRx;
    
    
    public partial class OrcGroup : ReactiveGroup<Orc> {
        
        private IEcsComponentManagerOf<Sword> _SwordManager;
        
        private IEcsComponentManagerOf<Shield> _ShieldManager;
        
        private IEcsComponentManagerOf<Health> _HealthManager;
        
        private int lastEntityId;
        
        private Sword Sword;
        
        private Shield Shield;
        
        private Health Health;
        
        public IEcsComponentManagerOf<Sword> SwordManager {
            get {
                return _SwordManager;
            }
            set {
                _SwordManager = value;
            }
        }
        
        public IEcsComponentManagerOf<Shield> ShieldManager {
            get {
                return _ShieldManager;
            }
            set {
                _ShieldManager = value;
            }
        }
        
        public IEcsComponentManagerOf<Health> HealthManager {
            get {
                return _HealthManager;
            }
            set {
                _HealthManager = value;
            }
        }
        
        public override System.Collections.Generic.IEnumerable<UniRx.IObservable<int>> Install(uFrame.ECS.APIs.IComponentSystem componentSystem) {
            SwordManager = componentSystem.RegisterComponent<Sword>();
            yield return SwordManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return SwordManager.RemovedObservable.Select(_=>_.EntityId);;
            ShieldManager = componentSystem.RegisterComponent<Shield>();
            yield return ShieldManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return ShieldManager.RemovedObservable.Select(_=>_.EntityId);;
            HealthManager = componentSystem.RegisterComponent<Health>();
            yield return HealthManager.CreatedObservable.Select(_=>_.EntityId);;
            yield return HealthManager.RemovedObservable.Select(_=>_.EntityId);;
        }
        
        public override bool Match(int entityId) {
            lastEntityId = entityId;
            if ((Sword = SwordManager[entityId]) == null) {
                return false;
            }
            if ((Shield = ShieldManager[entityId]) == null) {
                return false;
            }
            if ((Health = HealthManager[entityId]) == null) {
                return false;
            }
            return true;
        }
        
        public override Orc Select() {
            var item = new Orc();;
            item.EntityId = lastEntityId;
            item.Sword = Sword;
            item.Shield = Shield;
            item.Health = Health;
            return item;
        }
    }
}
