# Pipe-Delimited-Text-File-to-String-Table-Conversion

## About
This simple console application aims to answer the question raised in https://stackoverflow.com/questions/69476261/excel-pipe-delimited-text-file-delimiter-not-aligned wherein the conversion of the contents of a pipe-delimited text file to a table-like string is done programmatically.

An example of the following pipe-delimited text file content:

```
Column A|Column B|Column C
1|2|3
2|22222|333333
3|3333|44
```

will be converted to:

```
Column A|Column B|Column C|
--------+--------+--------+
   1    |   2    |   3    |
--------+--------+--------+
   2    | 22222  | 333333 |
--------+--------+--------+
   3    |  3333  |   44   |
--------+--------+--------+
```

## Contribute
You are welcome to submit improvements and/or additional features in this simple project of mine. In doing so, I ask you to please do the following:

1. Create an issue
2. Fork the repository
3. Submit a pull request
4. Will get back to you after PR submission
