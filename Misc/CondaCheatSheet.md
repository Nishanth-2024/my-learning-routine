# Conda (Miniconda) Cheat Sheet

- list of conda env: `conda env list` or `conda info --envs`
- Create a new environment: `conda create --name <env_name> python=<version>`
- activate conda environment: `conda activate <env_name>`
- Deactivate the current environment: `conda deactivate`
- Remove an environment: `conda remove --name <env_name> --all`
- current environment (if activated): `conda info --envs`
  - The currently active environment will be marked with an asterisk (`*`).
- Check Python version in an environment: `conda run -n <env_name> python --version`
- Check Python Version in Each Environment
  - Brute Force.
    `sh
    conda activate <env_name>
    python --version
    `
  - Loop through by a script.
    `sh
    for env in $(conda env list | grep -o '^[^ ]*' | tail -n +3); do
    echo "Environment: $env"
    conda run -n $env python --version
    done
    `
- To prevent `conda` from activating the base environment by default when launching a shell
  - Add the following line to the end of the shell rc file or profile file (like `~/.zshrc`):
    `conda config --set auto_activate_base false`
