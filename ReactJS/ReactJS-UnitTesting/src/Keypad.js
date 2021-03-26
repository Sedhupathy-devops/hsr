import React from 'react';

function Keypad(props) {

    return <div className="container">
        <div className="row">
            <button className="btn btn-info m-2" value="1" onClick={props.onKeyClick}>1</button>
            <button className="btn btn-info m-2" value="2" onClick={props.onKeyClick}>2</button>
            <button className="btn btn-info m-2" value="3" onClick={props.onKeyClick}>3</button>
            <button className="btn btn-info m-2" value="/" onClick={props.onOperatorClick}>/</button>
        </div>
        <div className="row">
            <button className="btn btn-info m-2" value="4" onClick={props.onKeyClick}>4</button>
            <button className="btn btn-info m-2" value="5" onClick={props.onKeyClick}>5</button>
            <button className="btn btn-info m-2" value="6" onClick={props.onKeyClick}>6</button>
            <button className="btn btn-info m-2" value="X" onClick={props.onOperatorClick}>X</button>
        </div>
        <div className="row">
            <button className="btn btn-info m-2" value="7" onClick={props.onKeyClick}>7</button>
            <button className="btn btn-info m-2" value="8" onClick={props.onKeyClick}>8</button>
            <button className="btn btn-info m-2" value="9" onClick={props.onKeyClick}>9</button>
            <button className="btn btn-info m-2" value="-" onClick={props.onOperatorClick}>-</button>
        </div>
        <div className="row">
            <button className="btn btn-info m-2" value="Clear" onClick={props.onClearClick}>C</button>
            <button className="btn btn-info m-2" value="0" onClick={props.onKeyClick}>0</button>
            <button className="btn btn-info m-2" value="=" onClick={props.onEqualsClick}>=</button>
            <button className="btn btn-info m-2" value="+" onClick={props.onOperatorClick}>+</button>
        </div>
    </div>;
}
export default Keypad;