# Instructions!

## Do this first (ONLY ONCE)

```powershell
PS > ./init.ps1
```

and your envilonment should be ready.

## To play

To execute code test:

```powershell
npm run test 
```

To submit your code:

```powershell
npm run submit
```

## It's not working!?

NOTE: All contents are backed up in ./old directory.

### It's reading data/Program.cs!?

You may do either:

- Just remove it (./Program.cs should do your work)
- Add the following to .csproj:
  - ```
    <ItemGroup>
      <Build Remove="data/Program.cs" />
    </ItemGroup>
    ```

### The template is tasteless!

Run ``acc config-dir`` and edit the directory.
