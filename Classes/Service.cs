﻿namespace FinalAssignment.Classes {
    // service types:
    internal enum ServiceEnum {
        MAINTENANCE,
        DIAGNOSTICS,
        REPAIR,
        MISC,
        NONE
    }

    // service class
    internal class Service {

        private readonly Dictionary<ServiceEnum, Double> serviceCost = new Dictionary<ServiceEnum, Double>();

        // Constructor to initialize the pricing model with example services
        public Service() {
            serviceCost.Add(ServiceEnum.MAINTENANCE, 50.00);
            serviceCost.Add(ServiceEnum.DIAGNOSTICS, 80.00);
            serviceCost.Add(ServiceEnum.REPAIR, 150.00);
            serviceCost.Add(ServiceEnum.MISC, 30.00);
        }

        public double GetServicePrice(ServiceEnum serviceIn) {
            // get price for a service
            return this.serviceCost.GetValueOrDefault(serviceIn);
        }

        public Dictionary<ServiceEnum, Double> getAllServices() {
            return this.serviceCost;
        }

        internal static ServiceEnum getServiceFromString(String serviceNameIn) {
            // get a service using a string
            switch (serviceNameIn) {
                case "MAINTENANCE":
                    return ServiceEnum.MAINTENANCE;
                case "DIAGNOSTICS":
                    return ServiceEnum.DIAGNOSTICS;
                case "REPAIR":
                    return ServiceEnum.REPAIR;
                case "NONE":
                    return ServiceEnum.NONE;
                default:
                    return ServiceEnum.MISC;
            }
        }

        internal static String getStringFromService(ServiceEnum serviceIn) {
            // get a string using a service
            switch (serviceIn) {
                case ServiceEnum.MAINTENANCE:
                    return "MAINTENANCE";
                case ServiceEnum.DIAGNOSTICS:
                    return "DIAGNOSTICS";
                case ServiceEnum.REPAIR:
                    return "REPAIR";
                case ServiceEnum.NONE:
                    return "NONE";
                default:
                    return "MISC";
            }
        }

        internal static ServiceEnum getRecommendedService(String searchTermIn) {
            // recommends a service based on a search string
            switch (searchTermIn) {
                case "oil":
                    return ServiceEnum.MAINTENANCE;
                case "wheel":
                    return ServiceEnum.MAINTENANCE;
                case "tire":
                    return ServiceEnum.MAINTENANCE;
                case "brakes":
                    return ServiceEnum.MAINTENANCE;
                case "wipers":
                    return ServiceEnum.MAINTENANCE;


                case "lights":
                    return ServiceEnum.DIAGNOSTICS;
                case "electrical":
                    return ServiceEnum.DIAGNOSTICS;
                case "battery":
                    return ServiceEnum.DIAGNOSTICS;
                case "sound":
                    return ServiceEnum.DIAGNOSTICS;


                case "broken":
                    return ServiceEnum.REPAIR;
                case "cracked":
                    return ServiceEnum.DIAGNOSTICS;
                case "bent":
                    return ServiceEnum.DIAGNOSTICS;


                default:
                    return ServiceEnum.MISC;
            }
        }
    }
}

