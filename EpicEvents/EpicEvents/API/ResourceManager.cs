using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace EpicEvents
{
    public class ResourceManager
    {
        private List<Blip> m_Blips;
        private List<Ped> m_Peds;
        private List<Vehicle> m_Vehicles;

        public ResourceManager()
        {
            m_Blips = new List<Blip>();
            m_Peds = new List<Ped>();
            m_Vehicles = new List<Vehicle>();
        }

        #region Blips

        public Blip CreatBlip(Entity entity)
        {
            Blip b = new Blip(entity);
            m_Blips.Add(b);
            return b;
        }

        public Blip CreatBlip(Vector3 vector)
        {
            Blip b = new Blip(vector);
            m_Blips.Add(b);
            return b;
        }

        public Blip CreatBlip(Vector3 vector, float radius)
        {
            Blip b = new Blip(vector, radius);
            m_Blips.Add(b);
            return b;
        }

        public void RemoveBlip(Blip blip)
        {
            m_Blips.Remove(blip);

            if (blip.Exists())
                blip.Delete();
        }

        #endregion

        #region Peds

        public Ped CreatePed()
        {
            Ped p = new Ped();
            m_Peds.Add(p);
            return p;
        }

        public Ped CreatePed(Vector3 posistion)
        {
            Ped p = new Ped(posistion);
            m_Peds.Add(p);
            return p;
        }

        public Ped CreatePed(Predicate<Model> model)
        {
            Ped p = new Ped(model);
            m_Peds.Add(p);
            return p;
        }

        public Ped CreatePed(Vector3 posistion, float heading)
        {
            Ped p = new Ped(posistion, heading);
            m_Peds.Add(p);
            return p;
        }

        public Ped CreatePed(Predicate<Model> model, Vector3 posistion)
        {
            Ped p = new Ped(model, posistion);
            m_Peds.Add(p);
            return p;
        }

        public Ped CreatePed(Model model, Vector3 posistion, float heading)
        {
            Ped p = new Ped(model, posistion, heading);
            m_Peds.Add(p);
            return p;
        }

        public Ped CreatePed(Predicate<Model> model, Vector3 posistion, float heading)
        {
            Ped p = new Ped(model, posistion, heading);
            m_Peds.Add(p);
            return p;
        }

        public void RemovePed(Ped p)
        {
            m_Peds.Remove(p);

            if (p.Exists())
                p.Delete();
        }

        #endregion

        #region Vehicles

        public Vehicle CreateVehicle()
        {
            Vehicle v = new Vehicle();
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Vector3 posistion)
        {
            Vehicle v = new Vehicle(posistion);
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Predicate<Model> model)
        {
            Vehicle v = new Vehicle(model);
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Model model, Vector3 posistion)
        {
            Vehicle v = new Vehicle(model, posistion);
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Vector3 position, float heading)
        {
            Vehicle v = new Vehicle(position, heading);
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Predicate<Model> model, Vector3 position)
        {
            Vehicle v = new Vehicle(model, position);
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Model model, Vector3 posistion, float heading)
        {
            Vehicle v = new Vehicle(model, posistion, heading);
            m_Vehicles.Add(v);
            return v;
        }

        public Vehicle CreateVehicle(Predicate<Model> model, Vector3 position, float heading)
        {
            Vehicle v = new Vehicle(model, position, heading);
            m_Vehicles.Add(v);
            return v;
        }

        public void RemoveVehicle(Vehicle v)
        {
            m_Vehicles.Remove(v);

            if (v.Exists())
                v.Delete();
        }

        #endregion

        public void RemoveAll()
        {
            foreach (Blip b in m_Blips)
            {
                if (b.Exists())
                    b.Delete();
            }

            foreach (Ped p in m_Peds)
            {
                if (p.Exists())
                    p.Delete();
            }

            foreach (Vehicle v in m_Vehicles)
            {
                if (v.Exists())
                    v.Delete();
            }

            m_Blips = new List<Blip>();
            m_Peds = new List<Ped>();
            m_Vehicles = new List<Vehicle>();
        }
    }
}
