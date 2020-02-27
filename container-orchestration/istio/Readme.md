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
6. Create a namespace `istio-system`

    ```cmd
    ❯ kubectl create namespace istio-system
    ```

7. Install Istio's [Custom Resource Definitions (CRD)](https://kubernetes.io/docs/concepts/extend-kubernetes/api-extension/custom-resources/#customresourcedefinitions).

    ```cmd
    ❯ helm install istio-init -n istio-system .\istio-init\
    ```

8. Verify that all CRDs were successfully installed

    ```cmd
    ❯ kubectl get crds -n istio-system
    ```

9. Install **istio** and enable **grafana**

    ```cmd
    ❯ helm install istio -n istio-system .\istio\ --set grafana.enabled=true
    ```

10. Verify that the Istio services and Grafana are running

    ```cmd
    ❯ kubectl get svc -n istio-system
    ```

11. We can also see the Pods that are running

    ```cmd
    ❯ kubectl get po -n istio-system
    ```

12. We'll use the **default** namespace to create our application objects, so we'll apply the `istio-injection=enabled` label to that namespace to enable automatic sidecar injection

    ```cmd
    ❯ kubectl label namespace default istio-injection=enabled
    ```

13. Verify that the `istio-injection` was enabled for the **default** namespace

    ```cmd
    ❯ kubectl get namespace -L istio-injection
    ```

## Install people-api

**people-api** is a sample .NET Core api that comes packaged with **Istio**

```cmd
❯ kubectl apply -f .\istio\sqlserver -f .\istio\api
```

## Install Istio object

```cmd
❯ kubectl apply -f .\istio\api-istio
```

## Install grafana

```cmd
❯ kubectl apply -f .\istio\grafana
```

## View logs peopleapi

```cmd
❯ kubectl logs [people api pod's name] -c peopleapi
```

## Verify

> http://localhost/api/people



## Resources

1. [Deploying Istio with Kubernetes](https://www.linode.com/docs/kubernetes/how-to-deploy-istio-with-kubernetes/) - Updated on Tuesday, January 21, 2020.

2. [Istio Routing Basics](https://softwareengineeringdaily.com/2018/11/26/istio-routing-basics)
   - We have to install Kubernestes and Istio with automatic sidecare injection first

3. [The Ultimate Guide to the Kubernetes Dashboard: How to Install, Access, Authenticate and Add Heapster Metrics](https://www.replex.io/blog/how-to-install-access-and-add-heapster-metrics-to-the-kubernetes-dashboard)
   - Note: The newest dashboard UI can be found [here](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/)

4. [How To Install and Use Istio With Kubernetes](https://www.digitalocean.com/community/tutorials/how-to-install-and-use-istio-with-kubernetes)

5. [How to configure ingress gateway in istio?](https://stackoverflow.com/questions/56643594/how-to-configure-ingress-gateway-in-istio)

    > ingress-gateway -> virtual-service -> destination-rule [optional] -> service

7. [How to add custom port for istio ingress gateway?](https://stackoverflow.com/questions/56661765/how-to-add-custom-port-for-istio-ingress-gateway)

8. [Istio an introduction](https://rinormaloku.com/istio-an-introduction/)