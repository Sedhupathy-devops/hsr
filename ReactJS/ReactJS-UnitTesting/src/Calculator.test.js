import React from 'react';
import ReactDOM from 'react-dom';
import Calculator from './Calculator';
import renderer from 'react-test-renderer';


it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(<Calculator />, div);
    ReactDOM.unmountComponentAtNode(div);
});


it('renders correctly', () => {
    const Calc = renderer.create(<Calculator />).toJSON();
    expect(Calc).toMatchSnapshot();
});

