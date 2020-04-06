using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopThePed.API;
using UltimateBackup.API;
using Rage;

namespace EpicEvents
{
    public static class Wrapper
    {
        public static void SetPedItems(Ped p, string items)
        {
            p.Metadata.searchPed = items;
        }

        public static void SetVehicleItems(Vehicle v, string driver, string passenger, string trunk)
        {
            v.Metadata.searchDriver = driver;
            v.Metadata.searchPassenger = passenger;
            v.Metadata.searchTrunk = trunk;
        }

        public static void SetPedGunPermit(Ped p, bool state)
        {
            p.Metadata.hasGunPermit = state;
        }

        public static bool GetPedGunPermit(Ped p)
        {
            return p.Metadata.hasGunPermit;
        }

        public enum GunTypes { Handguns, Long_Guns, Both }

        public static void SetPedGunPermitType(Ped p, GunTypes guntype, bool Concealed)
        {
            switch (guntype)
            {
                case GunTypes.Handguns:
                    p.Metadata.gunLicense = "Handguns";
                    break;
                case GunTypes.Long_Guns:
                    p.Metadata.gunLicense = "Long guns";
                    break;
                case GunTypes.Both:
                    p.Metadata.gunLicense = "Handguns and long guns";
                    break;
            }

            if (Concealed)
            {
                p.Metadata.gunPermit = "Concealed";
            }
            else
            {
                p.Metadata.gunPermit = "Public";
            }
        }

        public static (string license, string type) GetPedGunPermitType(Ped p)
        {
            return (p.Metadata.gunLicense,p.Metadata.gunPermit);
        }

        public static void SetPedAlcohol(Ped p, bool state)
        {
            p.Metadata.stpAlcoholDetected = state;
        }

        public static void SetPedDrugs(Ped p, bool state)
        {
            p.Metadata.stpDrugsDetected = state;
        }

        public enum BackupType { Ambulance, code2, code3, felonystop, female, fire, k9, pursuit, roadblock, spikestrip, trafficstop }

        public static void CallBackup(BackupType type)
        {
            switch (type)
            {
                case BackupType.Ambulance:
                    UltimateBackup.API.Functions.callAmbulance();
                    break;
                case BackupType.code2:
                    UltimateBackup.API.Functions.callCode2Backup();
                    break;
                case BackupType.code3:
                    UltimateBackup.API.Functions.callCode3Backup();
                    break;
                case BackupType.felonystop:
                    UltimateBackup.API.Functions.callFelonyStopBackup();
                    break;
                case BackupType.female:
                    UltimateBackup.API.Functions.callFemaleBackup();
                    break;
                case BackupType.fire:
                    UltimateBackup.API.Functions.callFireDepartment();
                    break;
                case BackupType.k9:
                    UltimateBackup.API.Functions.callK9Backup();
                    break;
                case BackupType.pursuit:
                    UltimateBackup.API.Functions.callPursuitBackup();
                    break;
                case BackupType.roadblock:
                    UltimateBackup.API.Functions.callRoadBlockBackup();
                    break;
                case BackupType.spikestrip:
                    UltimateBackup.API.Functions.callSpikeStripsBackup();
                    break;
                case BackupType.trafficstop:
                    UltimateBackup.API.Functions.callTrafficStopBackup();
                    break;
            }
        }
    }
}
