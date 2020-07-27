import React from 'react';
import PropTypes from 'prop-types';

import { Form } from 'react-bootstrap';

import _ from 'lodash';

class CheckboxControl extends React.Component {
  static propTypes = {
    type: PropTypes.string,
    updateState: PropTypes.func,
    onChange: PropTypes.func,
    children: PropTypes.node,
  };

  changed = (e) => {
    // On change listener
    if (this.props.onChange) {
      this.props.onChange(e);
    }

    // Update state
    if (this.props.updateState && e.target.id) {
      // Use e.target.id insted of this.props.id because it comes from the controlId.
      this.props.updateState({ [e.target.id]: e.target.checked });
    }
  };

  render() {
    var props = _.omit(this.props, 'updateState');

    return (
      <Form.Check className="checkbox-control" type="checkbox" {...props} onChange={this.changed}>
        {this.props.children}
      </Form.Check>
    );
  }
}

export default CheckboxControl;
