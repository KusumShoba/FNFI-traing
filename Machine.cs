using System;
class Machine{
        public string SlN {get ; set; }
        public string Make {get ; set; }
        public string Model {get ; set; }
        public int Price {get ; set; }
        public override string ToString(){
            return string.Format("The sn: {0} \n The Make:{1} \n The model:{2} ,The Price tag:{3:C}",SlN,Make,Model,Price);
        }
     }
class MachineDatabase{
    private List<Machine> laptps=new List<Machine>();

    public void RegisterDevice(Machine mac){

    }
    public void UpdateDevice(string sn, Machine mac){
        
    }
    public List<Machine> GetAllRegisteredDevice(){
        return laptps;
        
    }
}