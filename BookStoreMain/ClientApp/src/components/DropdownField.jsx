import React from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

/*export default class*/class DropDownField/*Example*/ extends React.Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      dropdownOpen: false
    };
  }

  toggle() {
    this.setState(prevState => ({
      dropdownOpen: !prevState.dropdownOpen
    }));
  }

  render() {
    return (
      <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle}>
        <DropdownToggle caret>
          {this.props.title}
        </DropdownToggle>
        <DropdownMenu>
          {this.props.lines.map(line => <div><DropdownItem>{line.name}</DropdownItem> <DropdownItem divider /></div>)}
        </DropdownMenu>
      </Dropdown>
    );
  }
}

export default DropDownField;