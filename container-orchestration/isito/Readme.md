# Istio & Kubernetes on local machine

## Install Istio

1. Download the release of [Istio-1.4.5](https://github.com/istio/istio/releases/download/1.4.5/istio-1.4.5-win.zip)
2. Extract to, for example `C:\Dev\istio-1.4.5`
3. Add to `PATH` : `c:\Dev\istio-1.4.5\bin`
4. Verify `istioctl`

   ```cmd
   ❯ istioctl version
    2020-02-24T09:24:07.311692Z     warn    will use `--remote=false` to retrieve version info due to `no Istio pods in namespace "istio-system"`
    1.4.5
   ```

5. Change the working dir to `C:\Dev\istio-1.4.5\install\kubernetes\helm`
6. Install Istio's [Custom Resource Definitions (CRD)](https://kubernetes.io/docs/concepts/extend-kubernetes/api-extension/custom-resources/#customresourcedefinitions). It'll create a **Pod** namespace called `istio-system`

    ```cmd
    ❯ helm install istio-init .\istio-init\
    NAME: istio-init
    LAST DEPLOYED: Mon Feb 24 16:34:26 2020
    NAMESPACE: default
    STATUS: deployed
    REVISION: 1
    TEST SUITE: None
    ```

7. Verify that all CRDs were successfully installed

    ```cmd
    ❯ kubectl get crds
    NAME                                      CREATED AT
    adapters.config.istio.io                  2020-02-24T09:35:07Z
    attributemanifests.config.istio.io        2020-02-24T09:35:04Z
    authorizationpolicies.security.istio.io   2020-02-24T09:35:07Z
    clusterrbacconfigs.rbac.istio.io          2020-02-24T09:35:04Z
    destinationrules.networking.istio.io      2020-02-24T09:35:04Z
    envoyfilters.networking.istio.io          2020-02-24T09:35:05Z
    gateways.networking.istio.io              2020-02-24T09:35:05Z
    handlers.config.istio.io                  2020-02-24T09:35:08Z
    httpapispecbindings.config.istio.io       2020-02-24T09:35:05Z
    httpapispecs.config.istio.io              2020-02-24T09:35:05Z
    instances.config.istio.io                 2020-02-24T09:35:07Z
    meshpolicies.authentication.istio.io      2020-02-24T09:35:05Z
    policies.authentication.istio.io          2020-02-24T09:35:06Z
    quotaspecbindings.config.istio.io         2020-02-24T09:35:06Z
    quotaspecs.config.istio.io                2020-02-24T09:35:06Z
    rbacconfigs.rbac.istio.io                 2020-02-24T09:35:06Z
    rules.config.istio.io                     2020-02-24T09:35:06Z
    serviceentries.networking.istio.io        2020-02-24T09:35:06Z
    servicerolebindings.rbac.istio.io         2020-02-24T09:35:06Z
    serviceroles.rbac.istio.io                2020-02-24T09:35:06Z
    sidecars.networking.istio.io              2020-02-24T09:35:02Z
    templates.config.istio.io                 2020-02-24T09:35:07Z
    virtualservices.networking.istio.io       2020-02-24T09:35:07Z
    ```

8. Install **istio** and enable **grafana**

    ```cmd
    ❯ helm install istio .\istio\ --set grafana.enabled=true
    NAME: istio
    LAST DEPLOYED: Mon Feb 24 16:37:22 2020
    NAMESPACE: default
    STATUS: deployed
    REVISION: 1
    TEST SUITE: None
    NOTES:
    Thank you for installing Istio.
    Your release is named Istio.

    To get started running application with Istio, execute the following steps:
    1. Label namespace that application object will be deployed to by the following command (take default namespace as an example)

    $ kubectl label namespace default istio-injection=enabled
    $ kubectl get namespace -L istio-injection

    2. Deploy your applications

    $ kubectl apply -f <your-application>.yaml

    For more information on running Istio, visit: https://istio.io/
    ```

9. Verify that the Istio services and Grafana are running

    ```cmd
    ❯ kubectl get svc
    NAME                     TYPE           CLUSTER-IP       EXTERNAL-IP   PORT(S)
    AGE
    grafana                  ClusterIP      10.103.188.121   <none>        3000/TCP
    20m
    istio-citadel            ClusterIP      10.105.99.239    <none>        8060/TCP,15014/TCP
    20m
    istio-galley             ClusterIP      10.107.191.203   <none>        443/TCP,15014/TCP,9901/TCP
    20m
    istio-ingressgateway     LoadBalancer   10.96.72.65      localhost     15020:31177/TCP,80:31380/TCP,443:31390/TCP,31400:31400/TCP,15029:30060/TCP,15030:32409/TCP,15031:30538/TCP,15032:32128/TCP,15443:32372/TCP   20m
    istio-pilot              ClusterIP      10.101.216.254   <none>        15010/TCP,15011/TCP,8080/TCP,15014/TCP
    20m
    istio-policy             ClusterIP      10.101.241.249   <none>        9091/TCP,15004/TCP,15014/TCP
    20m
    istio-sidecar-injector   ClusterIP      10.102.242.3     <none>        443/TCP,15014/TCP
    20m
    istio-telemetry          ClusterIP      10.101.243.3     <none>        9091/TCP,15004/TCP,15014/TCP,42422/TCP
    20m
    kubernetes               ClusterIP      10.96.0.1        <none>        443/TCP
    7d
    prometheus               ClusterIP      10.103.165.147   <none>        9090/TCP
    20m
    ```

10. We can also see the Pods that are running

    ```cmd
    ❯ kubectl get po
    NAME                                      READY   STATUS      RESTARTS   AGE
    grafana-698d64686d-l44b9                  1/1     Running     0          22m
    istio-citadel-54f89d9dc6-bbkl7            1/1     Running     0          22m
    istio-galley-7b88f88bf8-f9gnc             1/1     Running     0          22m
    istio-ingressgateway-55bf5dcf5d-4pm5m     0/1     Pending     0          22m
    istio-init-crd-10-1.4.5-2mfbz             0/1     Completed   0          25m
    istio-init-crd-11-1.4.5-cxcrk             0/1     Completed   0          25m
    istio-init-crd-14-1.4.5-j7r8g             0/1     Completed   0          25m
    istio-pilot-54677c9d8d-vh9wj              0/2     Pending     0          22m
    istio-policy-747db998c7-9g86p             2/2     Running     1          22m
    istio-sidecar-injector-5984558d46-d5w6g   1/1     Running     0          22m
    istio-telemetry-94d7c7b4d-7b7t7           2/2     Running     1          22m
    prometheus-5bc799fd4c-f4462               0/1     Pending     0          22m
    ```

## Resources

1. [Deploying Istio with Kubernetes](https://www.linode.com/docs/kubernetes/how-to-deploy-istio-with-kubernetes/) - Updated on Tuesday, January 21, 2020.

2. [Istio Routing Basics](https://softwareengineeringdaily.com/2018/11/26/istio-routing-basics)
   - We have to install Kubernestes and Istio wtih automatic sidecare injection first