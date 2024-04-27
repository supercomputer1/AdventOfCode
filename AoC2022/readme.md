You can find the session cookie under developer tools -> network -> input -> request headers -> cookie when visiting https://adventofcode.com/2022/day/1/input  
```json 
{
    "AppSettings": {
        "AdventOfCodeSessionCookie": "session=BLABLA"
    } 
}
```


Written in vim with config: 
```vimscript
language messages English_United States

imap jk <esc>

filetype plugin indent on 
syntax on 
set number incsearch hlsearch hidden confirm nowrap
set tabstop=4 
set shiftwidth=4 
set expandtab 
set ai 
set cmdheight=2
set nobackup nowritebackup noswapfile
set path+=**
set mouse=a

set background=dark
if has("gui_running") 
    set background=light
endif

nmap <space>r :!run.cmd<cr>
nmap <space>f :vimgrep <cword> **/*.cs<cr>
```
