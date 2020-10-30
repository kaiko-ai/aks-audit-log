﻿using Prometheus;

namespace AKSKubeAuditReceiver
{
    public static class ForwarderStatistics
    {

        private static readonly Counter Sent =
            Metrics.CreateCounter("sysdig_aks_audit_log_kube_events", "Total number of kube events sent");

        private static readonly Counter Errors =
            Metrics.CreateCounter("sysdig_aks_audit_log_kube_events_error", "Total number of kube events sent with error result");

        private static readonly Counter Successes =
            Metrics.CreateCounter("sysdig_aks_audit_log_kube_events_success", "Total number of kube events sent with success result");

        private static readonly Counter Retries =
            Metrics.CreateCounter("sysdig_aks_audit_log_kube_events_retry", "Total number of times kube events sent had to be retried");

        private static MetricServer Server;
        //private static KestrelMetricServer Server;

        public static void InitServer()
        {
            var diagnosticSourceRegistration = DiagnosticSourceAdapter.StartListening();

            Server = new MetricServer(port: 5000);
            Server.Start();
        }

        public static void IncreaseSuccesses()
        {
            Successes.Inc();
        }
        public static void IncreaseErrors()
        {
            Errors.Inc();
        }
        public static void IncreaseSent()
        {
            Sent.Inc();
        }
        public static void IncreaseRetries()
        {
            Sent.Inc();
        }
    }
}
