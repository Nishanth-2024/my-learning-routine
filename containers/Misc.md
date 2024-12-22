# Containerisation

Docker, Podman and more ...

## Podman Cheatsheet

Great choice! Using the CLI can give you more control and flexibility. Here’s a concise list of essential Podman commands for regular use:

### Basic Commands

- **Check Podman Version**:

  ```sh
  podman --version
  ```

- **Pull an Image**:

  ```sh
  podman pull <image-name>
  ```

- **List Images**:

  ```sh
  podman images
  ```

- **Run a Container**:

  ```sh
  podman run -d --name <container-name> <image-name>
  ```

- **List Running Containers**:

  ```sh
  podman ps
  ```

- **List All Containers**:

  ```sh
  podman ps -a
  ```

- **Stop a Container**:

  ```sh
  podman stop <container-id|container-name>
  ```

- **Start a Container**:

  ```sh
  podman start <container-id|container-name>
  ```

- **Remove a Container**:

  ```sh
  podman rm <container-id|container-name>
  ```

- **Remove an Image**:

  ```sh
  podman rmi <image-id|image-name>
  ```

### Advanced Commands

- **Inspect a Container**:

  ```sh
  podman inspect <container-id|container-name>
  ```

- **View Container Logs**:

  ```sh
  podman logs <container-id|container-name>
  ```

- **Execute a Command in a Running Container**:

  ```sh
  podman exec -it <container-id|container-name> <command>
  ```

- **Build an Image from a Dockerfile**:

  ```sh
  podman build -t <image-name> -f <Dockerfile-path>
  ```

- **Commit Changes to a New Image**:

  ```sh
  podman commit <container-id|container-name> <new-image-name>
  ```

- **Tag an Image**:

  ```sh
  podman tag <image-id|image-name> <new-image-name>
  ```

- **Push an Image to a Registry**:

  ```sh
  podman push <image-name> <registry-url>
  ```

### Example

- downloading an MSSQL Server image
- creating a container, and
- accessing it from Azure Data Studio

1. Initialize a Podman Machine:

    ```sh
    podman machine init
    ```

2. Start the Podman Machine:

    ```sh
    podman machine start
    ```

3. Verify the Connection: Check the connection to ensure the machine is running properly:

    ```sh
    podman system connection list
    ```

4. Download the latest MSSQL Server image from the Microsoft Container Registry:

    ```sh
    podman pull mcr.microsoft.com/azure-sql-edge
    ```

5. Create and run a container from the pulled image. Replace `YourStrong!Passw0rd` with a secure password of your choice:

    ```sh
    podman run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong\!Passw0rd" -p 1433:1433 --name mssql -d mcr.microsoft.com/azure-sql-edge
    ```

6. Check the status of your container:

    ```sh
    podman ps
    ```
